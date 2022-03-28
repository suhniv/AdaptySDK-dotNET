using System.Threading.Tasks;
using XamarinAdaptySDK.Models;
using XamarinAdaptySDK.Models.Enums;
#if NETSTANDARD
using AttributionType = System.Object;
#elif IOS
using AttributionType = Foundation.NSDictionary;

#elif ANDROID
using AttributionType = Java.Lang.Object;
#endif


namespace XamarinAdaptySDK
{
    public interface ICrossAdapty
    {
        void Activate(string apiKey);
        void Activate(string apiKey, string userId);
        Task IdentifyAsync(string customerUserId);
        Task SetVariationIdAsync(string variationId, string transactionId);
        Task LogoutAsync();
        Task SetExternalAnalyticsEnabled(bool enabled = true);
        Task UpdateAttributionAsync(AttributionType attribution, AttributionNetwork attributionNetwork, string userId);
        Task<Paywall[]?> GetPaywallsAsync(bool forceUpdate = false);
        Task<Product[]?> GetProductsAsync(bool forceUpdate = false);
        Task<Promo?> GetPromoAsync();
        Task<PurchaserInfo?> MakePurchaseAsync(Product product);
        Task<PurchaserInfo?> RestorePurchasesAsync();
        Task<PurchaserInfo?> GetPurchaserInfoAsync(bool forceUpdate = false);
    }
}