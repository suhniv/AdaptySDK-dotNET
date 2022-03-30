﻿using System.Linq;
using System.Threading.Tasks;
using Foundation;
using XamarinAdaptySDK.Exceptions;
using XamarinAdaptySDK.Models;
using AttributionNetwork = XamarinAdaptySDK.Models.Enums.AttributionNetwork;
using NativeAdapty = AdaptyBinding.Adapty;

namespace XamarinAdaptySDK
{
    public partial class Adapty : ICrossAdapty
    {
        public void Activate(string apiKey)
        {
            NativeAdapty.Activate(apiKey);
        }

        public void Activate(string apiKey, string userId)
        {
            NativeAdapty.Activate(apiKey, userId);
        }

        public Task IdentifyAsync(string customerUserId)
        {
            var tcs = new TaskCompletionSource<bool>();

            NativeAdapty.Identify(customerUserId, error => { tcs.TrySetResult(error); });

            return tcs.Task;
        }

        public Task SetVariationIdAsync(string variationId, string transactionId)
        {
            var tcs = new TaskCompletionSource<bool>();

            NativeAdapty.SetVariationId(variationId, transactionId, error => { tcs.TrySetResult(error); });

            return tcs.Task;
        }

        public Task LogoutAsync()
        {
            var tcs = new TaskCompletionSource<bool>();

            NativeAdapty.Logout(error => { tcs.TrySetResult(error); });

            return tcs.Task;
        }

        public Task SetExternalAnalyticsEnabled(bool enabled = true)
        {
            var tcs = new TaskCompletionSource<bool>();

            NativeAdapty.SetExternalAnalyticsEnabled(enabled, error => { tcs.TrySetResult(error); });

            return tcs.Task;
        }

        public Task UpdateAttributionAsync(NSDictionary attribution, AttributionNetwork attributionNetwork,
            string userId)
        {
            var tcs = new TaskCompletionSource<bool>();

            NativeAdapty.UpdateAttribution(attribution, attributionNetwork switch
            {
                AttributionNetwork.Adjust => AdaptyBinding.AttributionNetwork.Adjust,
                AttributionNetwork.AppsFlyer => AdaptyBinding.AttributionNetwork.Appsflyer,
                AttributionNetwork.Branch => AdaptyBinding.AttributionNetwork.Branch,
                _ => AdaptyBinding.AttributionNetwork.Custom
            }, userId, error => { tcs.TrySetResult(error); });

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
                        var paywallsProducts = paywalls
                            .Select(p => p.Products)
                            .SelectMany(p => p)
                            .ToArray();

                        if (paywallsProducts.Any() && paywallsProducts.All(p => p.SkProduct != null))
                        {
                            var crossPaywalls = paywalls.Select(p => p.ToPaywall());

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
                                    Products = products.Select(p => p.ToProduct()).ToArray()
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
                    tcs.TrySetException(new AdaptySdkException(error.Description));
                }
            });

            return tcs.Task;
        }

        public Task<Product[]?> GetProductsAsync(bool forceUpdate = false)
        {
            var tcs = new TaskCompletionSource<Product[]?>();

            NativeAdapty.GetPaywallsWithForceUpdate(forceUpdate, (_, products, error) =>
            {
                if (error == null)
                {
                    if (products != null && products.Any())
                    {
                        if (products.Any(p => p.SkProduct != null))
                        {
                            tcs.TrySetResult(products.Select(p => p.ToProduct()).ToArray());
                        }
                    }
                    else
                    {
                        tcs.TrySetResult(null);
                    }
                }
                else
                {
                    tcs.TrySetException(new AdaptySdkException(error.Description));
                }
            });

            return tcs.Task;
        }

        public Task<Promo?> GetPromoAsync()
        {
            var tcs = new TaskCompletionSource<Promo?>();

            NativeAdapty.GetPromo((promo, error) => { tcs.TrySetResult(promo.ToPromo, error); });

            return tcs.Task;
        }

        public Task<PurchaserInfo?> MakePurchaseAsync(Product product)
        {
            var tcs = new TaskCompletionSource<PurchaserInfo?>();

            NativeAdapty.MakePurchaseWithProduct(product.NativeProduct, null,
                (purchaserInfo, _, _, _, error) => { tcs.TrySetResult(purchaserInfo.ToPurchaserInfo, error); });

            return tcs.Task;
        }

        public Task<PurchaserInfo?> RestorePurchasesAsync()
        {
            var tcs = new TaskCompletionSource<PurchaserInfo?>();

            NativeAdapty.RestorePurchasesWithCompletion((purchaserInfo, _, _, error) =>
            {
                tcs.TrySetResult(purchaserInfo.ToPurchaserInfo, error);
            });

            return tcs.Task;
        }

        public Task<PurchaserInfo?> GetPurchaserInfoAsync(bool forceUpdate = false)
        {
            var tcs = new TaskCompletionSource<PurchaserInfo?>();

            NativeAdapty.GetPurchaserInfoWithForceUpdate(forceUpdate,
                (purchaserInfo, error) => { tcs.TrySetResult(purchaserInfo.ToPurchaserInfo, error); });

            return tcs.Task;
        }
    }
}