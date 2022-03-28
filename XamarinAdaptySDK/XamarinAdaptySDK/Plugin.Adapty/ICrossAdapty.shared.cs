using System.Threading.Tasks;
using Plugin.Adapty.Models;
using Plugin.Adapty.Models.Enums;
#if NETSTANDARD
using AttributionType = System.Object;
#elif IOS
using AttributionType = Foundation.NSDictionary;
#elif ANDROID
using AttributionType = Java.Lang.Object;
#endif


namespace Plugin.Adapty
{
    public interface ICrossAdapty
    {
        void Activate(string apiKey);
        void Activate(string apiKey, string userId);
        void SyncPurchases();
        Task UpdateAttributionAsync(AttributionType attribution, CrossAttributionNetwork attributionNetwork, string userId);
        Task<Paywall[]?> GetPaywallsAsync(bool forceUpdate = false);
        Task<Product[]?> GetProductsAsync(bool forceUpdate = false);
        Task<PurchaserInfo?> MakePurchaseAsync(Product product);
        Task<bool> RestorePurchasesAsync();
        Task<PurchaserInfo?> GetPurchaserInfoAsync(bool forceUpdate = false);
    }
}