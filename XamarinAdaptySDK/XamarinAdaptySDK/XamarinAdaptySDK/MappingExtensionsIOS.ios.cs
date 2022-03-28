using System;
using System.Collections.Generic;
using System.Linq;
using AdaptyBinding;
using Foundation;
using XamarinAdaptySDK.Models;
using XamarinAdaptySDK.Models.Enums;
using NPeriodUnit = AdaptyBinding.PeriodUnit;
using PeriodUnit = XamarinAdaptySDK.Models.Enums.PeriodUnit;

namespace XamarinAdaptySDK
{
    public static class MappingExtensionsIos
    {
        public static Paywall ToPaywall(this PaywallModel paywallModel) => new()
        {
            DeveloperId = paywallModel.DeveloperId,
            Products = paywallModel.Products.Select(ToProduct).ToArray(),
            CustomPayload = paywallModel.CustomPayloadString,
            Name = paywallModel.Name,
            AbTestName = paywallModel.AbTestName,
            VisualPaywall = paywallModel.VisualPaywall,
            VariationId = paywallModel.VariationId,
            IsPromo = paywallModel.IsPromo,
            Revision = (int)paywallModel.Revision
        };

        public static Product ToProduct(this ProductModel productModel) => new()
        {
            NativeProduct = productModel,
            Id = productModel.VendorProductId,
            LocalizedTitle = productModel.LocalizedTitle,
            LocalizedDescription = productModel.LocalizedDescription,
            LocalizedPrice = productModel.LocalizedPrice,
            CurrencyCode = productModel.CurrencyCode,
            CurrencySymbol = productModel.CurrencySymbol,
            MicrosPrice = Convert.ToInt64((productModel.SkProduct?.Price.DoubleValue ?? default) * 1000000),
            SubscriptionPeriod = new()
            {
                Unit = productModel.SubscriptionPeriod?.Unit.ToPeriodUnit() ?? PeriodUnit.Unknown
            },
            FreeTrialPeriod = new()
            {
                Unit = productModel.IntroductoryDiscount?.SubscriptionPeriod.Unit.ToPeriodUnit() ?? PeriodUnit.Unknown
            }
        };

        public static PeriodUnit ToPeriodUnit(this NPeriodUnit periodUnit) => periodUnit switch
        {
            NPeriodUnit.Day => PeriodUnit.Day,
            NPeriodUnit.Week => PeriodUnit.Week,
            NPeriodUnit.Month => PeriodUnit.Month,
            NPeriodUnit.Year => PeriodUnit.Year,
            _ => PeriodUnit.Unknown
        };

        public static Promo ToPromo(this PromoModel promoModel) => new()
        {
            Paywall = promoModel.Paywall?.ToPaywall(),
            ExpiresAt = promoModel.ExpiresAt?.ToDateTime(),
            PromoType = promoModel.PromoType,
            VariationId = promoModel.VariationId
        };

        public static PurchaserInfo ToPurchaserInfo(this PurchaserInfoModel purchaserInfoModel) => new()
        {
            ProfileId = purchaserInfoModel.ProfileId,
            CustomerUserId = purchaserInfoModel.CustomerUserId,
            PaidAccessLevels = purchaserInfoModel.AccessLevels.ToPaidAccessLevelInfos(),
            Subscriptions = purchaserInfoModel.Subscriptions.ToSubscriptions(),
            NonSubscriptions = purchaserInfoModel.NonSubscriptions.ToNonSubscriptions()
        };

        private static Dictionary<string, PaidAccessLevelInfo> ToPaidAccessLevelInfos(
            this NSDictionary<NSString, AccessLevelInfoModel> accessLevelInfos)
        {
            var result = new Dictionary<string, PaidAccessLevelInfo>();

            foreach (var (key, value) in accessLevelInfos)
            {
                if (ObjCRuntime.Runtime.GetNSObject<AccessLevelInfoModel>(value.Handle) is { } accessLevelInfoModel)
                {
                    result.Add((NSString)key, accessLevelInfoModel.ToPaidAccessLevelInfo());
                }
            }

            return result;
        }

        private static PaidAccessLevelInfo ToPaidAccessLevelInfo(this AccessLevelInfoModel accessLevelInfoModel) =>
            new()
            {
                Id = accessLevelInfoModel.Id,
                IsActive = accessLevelInfoModel.IsActive,
                VendorProductId = accessLevelInfoModel.VendorProductId,
                Store = accessLevelInfoModel.Store switch
                {
                    Constants.AppStore => Store.AppStore,
                    Constants.PlayStore => Store.PlayStore,
                    Constants.Adapty => Store.Adapty,
                    _ => Store.Unknown
                },
                ActivatedAt = accessLevelInfoModel.ActivatedAt?.ToDateTime(),
                RenewedAt = accessLevelInfoModel.RenewedAt?.ToDateTime(),
                ExpiresAt = accessLevelInfoModel.ExpiresAt?.ToDateTime(),
                IsLifetime = accessLevelInfoModel.IsLifetime,
                ActiveIntroductoryOfferType = accessLevelInfoModel.ActiveIntroductoryOfferType switch
                {
                    Constants.FreeTrial => OfferType.FreeTrial,
                    Constants.PayAsYouGo => OfferType.PayAsYouGo,
                    Constants.PayUpFront => OfferType.PayUpFront,
                    _ => OfferType.Unknown
                },
                ActivePromotionalOfferType = accessLevelInfoModel.ActivePromotionalOfferType switch
                {
                    Constants.FreeTrial => OfferType.FreeTrial,
                    Constants.PayAsYouGo => OfferType.PayAsYouGo,
                    Constants.PayUpFront => OfferType.PayUpFront,
                    _ => OfferType.Unknown
                },
                WillRenew = accessLevelInfoModel.WillRenew,
                IsInGracePeriod = accessLevelInfoModel.IsInGracePeriod,
                UnsubscribedAt = accessLevelInfoModel.UnsubscribedAt?.ToDateTime(),
                BillingIssueDetectedAt = accessLevelInfoModel.BillingIssueDetectedAt?.ToDateTime()
            };

        private static Dictionary<string, Subscription> ToSubscriptions(
            this NSDictionary<NSString, SubscriptionInfoModel> subscriptionInfos)
        {
            var result = new Dictionary<string, Subscription>();

            foreach (var (key, value) in subscriptionInfos)
            {
                if (ObjCRuntime.Runtime.GetNSObject<SubscriptionInfoModel>(value.Handle) is { } subscriptionInfoModel)
                {
                    result.Add((NSString)key, subscriptionInfoModel.ToSubscription());
                }
            }

            return result;
        }

        private static Subscription ToSubscription(this SubscriptionInfoModel subscriptionInfoModel) => new()
        {
            IsActive = subscriptionInfoModel.IsActive,
            VendorProductId = subscriptionInfoModel.VendorProductId,
            Store = subscriptionInfoModel.Store switch
            {
                Constants.AppStore => Store.AppStore,
                Constants.PlayStore => Store.PlayStore,
                Constants.Adapty => Store.Adapty,
                _ => Store.Unknown
            },
            ActivatedAt = subscriptionInfoModel.ActivatedAt?.ToDateTime(),
            RenewedAt = subscriptionInfoModel.RenewedAt?.ToDateTime(),
            ExpiresAt = subscriptionInfoModel.ExpiresAt?.ToDateTime(),
            StartsAt = subscriptionInfoModel.StartsAt?.ToDateTime(),
            IsLifetime = subscriptionInfoModel.IsLifetime,
            ActiveIntroductoryOfferType = subscriptionInfoModel.ActiveIntroductoryOfferType switch
            {
                Constants.FreeTrial => OfferType.FreeTrial,
                Constants.PayAsYouGo => OfferType.PayAsYouGo,
                Constants.PayUpFront => OfferType.PayUpFront,
                _ => OfferType.Unknown
            },
            ActivePromotionalOfferType = subscriptionInfoModel.ActivePromotionalOfferType switch
            {
                Constants.FreeTrial => OfferType.FreeTrial,
                Constants.PayAsYouGo => OfferType.PayAsYouGo,
                Constants.PayUpFront => OfferType.PayUpFront,
                _ => OfferType.Unknown
            },
            WillRenew = subscriptionInfoModel.WillRenew,
            IsInGracePeriod = subscriptionInfoModel.IsInGracePeriod,
            UnsubscribedAt = subscriptionInfoModel.UnsubscribedAt?.ToDateTime(),
            BillingIssueDetectedAt = subscriptionInfoModel.BillingIssueDetectedAt?.ToDateTime(),
            IsSandBox = subscriptionInfoModel.IsSandbox,
            CancellationReason = subscriptionInfoModel.CancellationReason,
            VendorTransactionId = subscriptionInfoModel.VendorTransactionId,
            VendorOriginalTransactionId = subscriptionInfoModel.VendorOriginalTransactionId
        };

        private static Dictionary<string, NonSubscription[]> ToNonSubscriptions(
            this NSDictionary<NSString, NSArray<NonSubscriptionInfoModel>> nonSubscriptionInfos)
        {
            var result = new Dictionary<string, NonSubscription[]>();

            foreach (var (key, value) in nonSubscriptionInfos)
            {
                if (NSArray.ArrayFromHandle<NonSubscriptionInfoModel>(value.Handle) is { } nonSubscriptions)
                {
                    result.Add((NSString)key, nonSubscriptions.ToNonSubscriptions().ToArray());
                }
            }

            return result;
        }

        private static IEnumerable<NonSubscription> ToNonSubscriptions(
            this NonSubscriptionInfoModel[] nonSubscriptionInfoModels) =>
            nonSubscriptionInfoModels.Select(nonSubscription => new NonSubscription
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
                IsRefund = nonSubscription.IsRefund,
                VendorTransactionId = nonSubscription.VendorTransactionId,
                VendorOriginalTransactionId = nonSubscription.VendorOriginalTransactionId
            });
    }
}