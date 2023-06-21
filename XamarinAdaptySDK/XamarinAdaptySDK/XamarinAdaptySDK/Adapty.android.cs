using System;
using System.Threading.Tasks;
using Com.Adapty.Models;
using XamarinAdaptySDK.Models;
using XamarinAdaptySDK.Models.Enums;
using Xamarin.Essentials;
using XamarinAdaptySDK.AndroidCallback;
using NativeAdapty = Com.Adapty.Adapty;
using Object = Java.Lang.Object;

namespace XamarinAdaptySDK
{
    public partial class Adapty : ICrossAdapty
    {
        public void Activate(string apiKey)
        {
            NativeAdapty.Activate(Platform.AppContext, apiKey);
        }

        public void Activate(string apiKey, string userId, bool observerMode)
        {
            NativeAdapty.Activate(Platform.AppContext, apiKey, observerMode, userId);
        }

        public Task IdentifyAsync(string customerUserId)
        {
            var callback = new VoidCallback();
            NativeAdapty.Identify(customerUserId, callback);
            return callback.Task;
        }

        public Task SetVariationIdAsync(string variationId, string transactionId)
        {
            var callback = new VoidCallback();
            NativeAdapty.SetVariationId(transactionId, variationId, callback);
            return callback.Task;
        }

        public Task LogoutAsync()
        {
            var callback = new VoidCallback();
            NativeAdapty.Logout(callback);
            return callback.Task;
        }

        public Task LogShowPaywallAsync(Paywall paywall)
        {
            throw new NotImplementedException();
        }

        public Task SetExternalAnalyticsEnabled(bool enabled = true)
        {
            throw new NotSupportedException();
        }

        public Task UpdateAttributionAsync(Object attribution, AttributionNetwork attributionNetwork, string userId)
        {
            var callback = new VoidCallback();
            NativeAdapty.UpdateAttribution(attribution, attributionNetwork switch
            {
                AttributionNetwork.Adjust => AdaptyAttributionSource.Adjust,
                AttributionNetwork.AppsFlyer => AdaptyAttributionSource.Appsflyer,
                AttributionNetwork.Branch => AdaptyAttributionSource.Branch,
                _ => AdaptyAttributionSource.Custom
            }, userId, callback);
            return callback.Task;
        }

        public async Task<Paywall?> GetPaywallAsync(string id)
        {
            var paywallCallback = new ResultCallback<AdaptyPaywall, Paywall>(x => x.ToPaywall());
            NativeAdapty.GetPaywall(id, paywallCallback);
            var paywall = await paywallCallback;

            if (paywall is not null)
            {
                var productsCallback = new ListResultCallback<AdaptyPaywallProduct, Product>(x => x.ToProduct());
                NativeAdapty.GetPaywallProducts(paywall.NativePaywall, productsCallback);
                paywall.Products = (await productsCallback)?.ToArray()!;
            }

            return paywall;
        }

        public Task<Paywall[]?> GetPaywallsAsync(bool forceUpdate = false)
        {
            throw new NotSupportedException();
        }

        public Task<Product[]?> GetProductsAsync(bool forceUpdate = false)
        {
            throw new NotSupportedException();
        }

        public Task<Promo?> GetPromoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PurchaserInfo?> MakePurchaseAsync(Product product)
        {
            var callback = new ResultCallback<AdaptyProfile, PurchaserInfo>(x => x.ToPurchaserInfo());
            NativeAdapty.MakePurchase(Platform.CurrentActivity, product.NativeProduct, callback);
            return callback.Task;
        }

        public Task<PurchaserInfo?> RestorePurchasesAsync()
        {
            var callback = new ResultCallback<AdaptyProfile, PurchaserInfo>(x => x.ToPurchaserInfo());
            NativeAdapty.RestorePurchases(callback);
            return callback.Task;
        }

        public Task<PurchaserInfo?> GetPurchaserInfoAsync(bool forceUpdate = false)
        {
            var callback = new ResultCallback<AdaptyProfile, PurchaserInfo>(x => x.ToPurchaserInfo());
            NativeAdapty.GetProfile(callback);
            return callback.Task;
        }
    }
}