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

        public void Activate(string apiKey, string userId)
        {
            NativeAdapty.Activate(Platform.AppContext, apiKey, userId);
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
            NativeAdapty.SetTransactionVariationId(transactionId, variationId, callback);
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
            var callback = new VoidCallback();
            NativeAdapty.SetExternalAnalyticsEnabled(enabled, callback);
            return callback.Task;
        }

        public Task UpdateAttributionAsync(Object attribution, AttributionNetwork attributionNetwork, string userId)
        {
            var callback = new VoidCallback();
            NativeAdapty.UpdateAttribution(attribution, attributionNetwork switch
            {
                AttributionNetwork.Adjust => AttributionType.Adjust,
                AttributionNetwork.AppsFlyer => AttributionType.Appsflyer,
                AttributionNetwork.Branch => AttributionType.Branch,
                _ => AttributionType.Custom
            }, userId, callback);
            return callback.Task;
        }

        public Task<Paywall[]?> GetPaywallsAsync(bool forceUpdate = false)
        {
            var callback = new GetPaywallsCallback();
            NativeAdapty.GetPaywalls(forceUpdate, callback);
            return callback.Task;
        }

        public Task<Product[]?> GetProductsAsync(bool forceUpdate = false)
        {
            throw new NotImplementedException();
        }

        public Task<Promo?> GetPromoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PurchaserInfo?> MakePurchaseAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaserInfo?> RestorePurchasesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PurchaserInfo?> GetPurchaserInfoAsync(bool forceUpdate = false)
        {
            throw new NotImplementedException();
        }
    }
}