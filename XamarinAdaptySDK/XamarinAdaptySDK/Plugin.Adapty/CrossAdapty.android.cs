using System.Threading.Tasks;
using Com.Adapty.Api;
using Java.Lang;
using Plugin.Adapty.Android.Callback;
using Plugin.Adapty.Models;
using Plugin.Adapty.Models.Enums;
using NativeAdapty = Com.Adapty.Adapty;

namespace Plugin.Adapty
{
    public partial class CrossAdapty : ICrossAdapty
    {
        public void Activate(string apiKey)
        {
            NativeAdapty.Activate(Xamarin.Essentials.Platform.AppContext, apiKey);
        }

        public void Activate(string apiKey, string userId)
        {
            NativeAdapty.Activate(Xamarin.Essentials.Platform.AppContext, apiKey, userId);
        }

        public void SyncPurchases()
        {
            NativeAdapty.SyncPurchases();
        }

        public Task UpdateAttributionAsync(Object attribution, CrossAttributionNetwork attributionNetwork,
            string userId)
        {
            NativeAdapty.UpdateAttribution(attribution, attributionNetwork switch
            {
                CrossAttributionNetwork.Adjust => AttributionType.Adjust,
                CrossAttributionNetwork.AppsFlyer => AttributionType.Appsflyer,
                CrossAttributionNetwork.Branch => AttributionType.Branch,
                _ => AttributionType.Branch
            });

            return Task.CompletedTask;
        }

        public Task<Paywall[]?> GetPaywallsAsync(bool forceUpdate = false)
        {
            var callback = new GetPaywallsCallback();
            NativeAdapty.GetPaywalls(callback);
            return callback.CallbackTask;
        }

        public Task<Product[]?> GetProductsAsync(bool forceUpdate = false)
        {
            var callback = new GetProductsCallback();
            NativeAdapty.GetPaywalls(callback);
            return callback.CallbackTask;
        }

        public async Task<PurchaserInfo?> MakePurchaseAsync(Product product)
        {
            var callback = new MakePurchaseCallback();
            NativeAdapty.MakePurchase(Xamarin.Essentials.Platform.CurrentActivity, product.NativeProduct, callback);
            await callback.CallbackTask;

            return await GetPurchaserInfoAsync();
        }

        public Task<bool> RestorePurchasesAsync()
        {
            var callback = new RestorePurchasesCallback();
            NativeAdapty.RestorePurchases(callback);
            return callback.CallbackTask;
        }

        public Task<PurchaserInfo?> GetPurchaserInfoAsync(bool forceUpdate = false)
        {
            var callback = new GetPurchaserInfoCallback();
            NativeAdapty.GetPurchaserInfo(callback);
            return callback.CallbackTask;
        }
    }
}