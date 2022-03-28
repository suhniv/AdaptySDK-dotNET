using AdaptyBinding;
using Plugin.Adapty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using Plugin.Adapty.Models.Enums;
using NativeAdapty = AdaptyBinding.Adapty;

namespace Plugin.Adapty
{
    public partial class CrossAdapty : ICrossAdapty
    {
        public void Activate(string apiKey)
        {
            NativeAdapty.Activate(apiKey);
        }

        public void Activate(string apiKey, string userId)
        {
            NativeAdapty.Activate(apiKey, userId);
        }

        public void SyncPurchases()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAttributionAsync(NSDictionary attribution, CrossAttributionNetwork attributionNetwork,
            string userId)
        {
            var tcs = new TaskCompletionSource<bool>();

            NativeAdapty.UpdateAttribution(attribution, attributionNetwork switch
            {
                CrossAttributionNetwork.Adjust => AttributionNetwork.Adjust,
                CrossAttributionNetwork.AppsFlyer => AttributionNetwork.Appsflyer,
                CrossAttributionNetwork.Branch => AttributionNetwork.Branch,
                _ => AttributionNetwork.Custom
            }, userId, error => { tcs.TrySetResult(true); });

            return tcs.Task;
        }

        public Task<Paywall[]?> GetPaywallsAsync(bool forceUpdate = false)
        {
            var tcs = new TaskCompletionSource<Paywall[]?>();

            NativeAdapty.GetPaywallsWithForceUpdate(forceUpdate, (paywalls, products, error) =>
            {
                if (error == null)
                {
                    if (paywalls != null && paywalls.Any())
                    {
                        var paywallsProducts = paywalls.Select(p => p.Products).SelectMany(p => p).ToArray();

                        if (paywallsProducts.Any() && paywallsProducts.All(p => p.SkProduct != null))
                        {
                            var crossPaywalls = Enumerable.Range(0, (int) paywalls.Count)
                                .Select(i => new Paywall
                                {
                                    DeveloperId = paywalls[i].DeveloperId,
                                    Products = paywalls[i].Products.Select(ConvertProduct).ToArray(),
                                    CustomPayload = paywalls[i].CustomPayloadString
                                });

                            tcs.TrySetResult(crossPaywalls.ToArray());
                        }
                    }
                    else if (products != null && products.Any())
                    {
                        //Here must be All but there is a bug in Adapty
                        //if (products.All(p => p.SkProduct != null))
                        if (products.Any(p => p.SkProduct != null))
                        {
                            tcs.TrySetResult(new[]
                            {
                                new Paywall
                                {
                                    Products = products.Select(ConvertProduct).ToArray()
                                }
                            });
                        }
                    }
                    else
                    {
                        tcs.TrySetResult(null);
                    }
                }
                else
                {
                    tcs.TrySetResult(null);
                }
            });

            return tcs.Task;
        }

        public Task<Product[]?> GetProductsAsync(bool forceUpdate = false)
        {
            var tcs = new TaskCompletionSource<Product[]?>();

            NativeAdapty.GetPaywallsWithForceUpdate(forceUpdate, (paywalls, products, error) =>
            {
                if (error == null)
                {
                    if (products != null && products.Any())
                    {
                        if (products.Any(p => p.SkProduct != null))
                        {
                            tcs.TrySetResult(products.Select(ConvertProduct).ToArray());
                        }
                    }
                    else
                    {
                        tcs.TrySetResult(null);
                    }
                }
                else
                {
                    tcs.TrySetResult(null);
                }
            });

            return tcs.Task;
        }

        public Task<PurchaserInfo?> MakePurchaseAsync(Product product)
        {
            var tcs = new TaskCompletionSource<PurchaserInfo?>();

            NativeAdapty.MakePurchaseWithProduct(product.NativeProduct, null,
                (purchaserInfo, receipt, appleValidationResult, prod, error) =>
                {
                    if (error == null)
                    {
                        tcs.TrySetResult(new PurchaserInfo
                        {
                            PaidAccessLevels = ConvertPaidAccessLevelInfo(purchaserInfo.AccessLevels),
                            Subscriptions = ConvertSubscriptions(purchaserInfo.Subscriptions),
                            NonSubscriptions = ConvertNonSubscriptions(purchaserInfo.NonSubscriptions)
                        });
                    }
                    else
                    {
                        tcs.TrySetResult(null);
                    }
                });

            return tcs.Task;
        }

        public Task<bool> RestorePurchasesAsync()
        {
            var tcs = new TaskCompletionSource<bool>();

            NativeAdapty.RestorePurchasesWithCompletion((model, s, arg3, error) => tcs.TrySetResult(error == null));

            return tcs.Task;
        }

        public Task<PurchaserInfo?> GetPurchaserInfoAsync(bool forceUpdate = false)
        {
            var tcs = new TaskCompletionSource<PurchaserInfo?>();

            NativeAdapty.GetPurchaserInfoWithForceUpdate(forceUpdate, (purchaserInfo, error) =>
            {
                if (error == null)
                {
                    tcs.TrySetResult(new PurchaserInfo
                    {
                        PaidAccessLevels = ConvertPaidAccessLevelInfo(purchaserInfo.AccessLevels),
                        Subscriptions = ConvertSubscriptions(purchaserInfo.Subscriptions),
                        NonSubscriptions = ConvertNonSubscriptions(purchaserInfo.NonSubscriptions)
                    });
                }
                else
                {
                    tcs.TrySetResult(null);
                }
            });

            return tcs.Task;
        }

        private Product ConvertProduct(ProductModel product) => new Product
        {
            NativeProduct = product,
            Id = product.VendorProductId,
            LocalizedTitle = product.LocalizedTitle,
            LocalizedDescription = product.LocalizedDescription,
            LocalizedPrice = product.LocalizedPrice,
            CurrencyCode = product.CurrencyCode,
            CurrencySymbol = product.CurrencySymbol,
            MicrosPrice = Convert.ToInt64((product.SkProduct?.Price.DoubleValue ?? default) * 1000000),
            SubscriptionPeriod = product.SubscriptionPeriod?.Unit switch
            {
                PeriodUnit.Day => TimeSpan.FromDays(1) * (int) product.SubscriptionPeriod.NumberOfUnits,
                PeriodUnit.Week => TimeSpan.FromDays(7) * (int) product.SubscriptionPeriod.NumberOfUnits,
                PeriodUnit.Month => TimeSpan.FromDays(31) * (int) product.SubscriptionPeriod.NumberOfUnits,
                PeriodUnit.Year => TimeSpan.FromDays(365) * (int) product.SubscriptionPeriod.NumberOfUnits,
                PeriodUnit.Unknown => TimeSpan.Zero,
                _ => TimeSpan.Zero
            },
            FreeTrialPeriod = product.IntroductoryDiscount?.SubscriptionPeriod.Unit switch
            {
                PeriodUnit.Day => TimeSpan.FromDays(1) *
                                  (int) product.IntroductoryDiscount.SubscriptionPeriod.NumberOfUnits,
                PeriodUnit.Week => TimeSpan.FromDays(7) *
                                   (int) product.IntroductoryDiscount.SubscriptionPeriod.NumberOfUnits,
                PeriodUnit.Month => TimeSpan.FromDays(31) *
                                    (int) product.IntroductoryDiscount.SubscriptionPeriod.NumberOfUnits,
                PeriodUnit.Year => TimeSpan.FromDays(365) *
                                   (int) product.IntroductoryDiscount.SubscriptionPeriod.NumberOfUnits,
                PeriodUnit.Unknown => TimeSpan.Zero,
                _ => TimeSpan.Zero
            }
        };


        private IDictionary<string, PaidAccessLevelInfo> ConvertPaidAccessLevelInfo(NSDictionary paidAccessLevelsInfos)
        {
            var result = new Dictionary<string, PaidAccessLevelInfo>();

            foreach (var (key, value) in paidAccessLevelsInfos)
            {
                var paidAccessLevelInfoModel = ObjCRuntime.Runtime.GetNSObject<AccessLevelInfoModel>(value.Handle);

                result.Add((NSString) key, new PaidAccessLevelInfo
                {
                    Id = paidAccessLevelInfoModel.Id,
                    IsActive = paidAccessLevelInfoModel.IsActive,
                    VendorProductId = paidAccessLevelInfoModel.VendorProductId,
                    Store = paidAccessLevelInfoModel.Store switch
                    {
                        Constants.AppStore => Store.AppStore,
                        Constants.PlayStore => Store.PlayStore,
                        Constants.Adapty => Store.Adapty,
                        _ => Store.Unknown
                    },
                    ActivatedAt = paidAccessLevelInfoModel.ActivatedAt?.ToDateTime(),
                    RenewedAt = paidAccessLevelInfoModel.RenewedAt?.ToDateTime(),
                    ExpiresAt = paidAccessLevelInfoModel.ExpiresAt?.ToDateTime(),
                    IsLifetime = paidAccessLevelInfoModel.IsLifetime,
                    ActiveIntroductoryOfferType = paidAccessLevelInfoModel.ActiveIntroductoryOfferType switch
                    {
                        Constants.FreeTrial => OfferType.FreeTrial,
                        Constants.PayAsYouGo => OfferType.PayAsYouGo,
                        Constants.PayUpFront => OfferType.PayUpFront,
                        _ => OfferType.Unknown
                    },
                    ActivePromotionalOfferType = paidAccessLevelInfoModel.ActivePromotionalOfferType switch
                    {
                        Constants.FreeTrial => OfferType.FreeTrial,
                        Constants.PayAsYouGo => OfferType.PayAsYouGo,
                        Constants.PayUpFront => OfferType.PayUpFront,
                        _ => OfferType.Unknown
                    },
                    WillRenew = paidAccessLevelInfoModel.WillRenew,
                    IsInGracePeriod = paidAccessLevelInfoModel.IsInGracePeriod,
                    UnsubscribedAt = paidAccessLevelInfoModel.UnsubscribedAt?.ToDateTime(),
                    BillingIssueDetectedAt = paidAccessLevelInfoModel.BillingIssueDetectedAt?.ToDateTime()
                });
            }

            return result;
        }

        private IDictionary<string, Subscription> ConvertSubscriptions(NSDictionary subscriptionsInfoModels)
        {
            var result = new Dictionary<string, Subscription>();

            foreach (var (key, value) in subscriptionsInfoModels)
            {
                var subscription = ObjCRuntime.Runtime.GetNSObject<SubscriptionInfoModel>(value.Handle);

                result.Add((NSString) key, new Subscription
                {
                    IsActive = subscription.IsActive,
                    VendorProductId = subscription.VendorProductId,
                    Store = subscription.Store switch
                    {
                        Constants.AppStore => Store.AppStore,
                        Constants.PlayStore => Store.PlayStore,
                        Constants.Adapty => Store.Adapty,
                        _ => Store.Unknown
                    },
                    ActivatedAt = subscription.ActivatedAt?.ToDateTime(),
                    RenewedAt = subscription.RenewedAt?.ToDateTime(),
                    ExpiresAt = subscription.ExpiresAt?.ToDateTime(),
                    StartsAt = subscription.StartsAt?.ToDateTime(),
                    IsLifetime = subscription.IsLifetime,
                    ActiveIntroductoryOfferType = subscription.ActiveIntroductoryOfferType switch
                    {
                        Constants.FreeTrial => OfferType.FreeTrial,
                        Constants.PayAsYouGo => OfferType.PayAsYouGo,
                        Constants.PayUpFront => OfferType.PayUpFront,
                        _ => OfferType.Unknown
                    },
                    ActivePromotionalOfferType = subscription.ActivePromotionalOfferType switch
                    {
                        Constants.FreeTrial => OfferType.FreeTrial,
                        Constants.PayAsYouGo => OfferType.PayAsYouGo,
                        Constants.PayUpFront => OfferType.PayUpFront,
                        _ => OfferType.Unknown
                    },
                    WillRenew = subscription.WillRenew,
                    IsInGracePeriod = subscription.IsInGracePeriod,
                    UnsubscribedAt = subscription.UnsubscribedAt?.ToDateTime(),
                    BillingIssueDetectedAt = subscription.BillingIssueDetectedAt?.ToDateTime(),
                    IsSandBox = subscription.IsSandbox,
                    VendorTransactionId = subscription.VendorTransactionId,
                    VendorOriginalTransactionId = subscription.VendorOriginalTransactionId
                });
            }

            return result;
        }

        private IDictionary<string, NonSubscription[]> ConvertNonSubscriptions(NSDictionary nonSubscriptionsInfoModels)
        {
            var result = new Dictionary<string, NonSubscription[]>();

            foreach (var (key, value) in nonSubscriptionsInfoModels)
            {
                var nonSubscriptions = (NSArray<NonSubscriptionInfoModel>) value;

                result.Add((NSString) key, nonSubscriptions.Select(nonSubscription => new NonSubscription
                {
                    PurchaseId = nonSubscription.PurchaseId,
                    VendorProductId = nonSubscription.VendorProductId,
                    Store = nonSubscription.Store switch
                    {
                        Constants.AppStore => Store.AppStore,
                        Constants.PlayStore => Store.PlayStore,
                        Constants.Adapty => Store.Adapty,
                        _ => Store.Unknown
                    },
                    PurchasedAt = nonSubscription.PurchasedAt?.ToDateTime(),
                    IsOneTime = nonSubscription.IsOneTime,
                    IsSandBox = nonSubscription.IsSandbox,
                    VendorTransactionId = nonSubscription.VendorTransactionId,
                    VendorOriginalTransactionId = nonSubscription.VendorOriginalTransactionId
                }).ToArray());
            }

            return result;
        }
    }
}