#if IOS
using ProductModel = AdaptyBinding.ProductModel;
#elif ANDROID
using ProductModel = Com.Adapty.Models.ProductModel;
#endif

namespace XamarinAdaptySDK.Models
{
    public record Product
    {
#if IOS || ANDROID
        public ProductModel NativeProduct { get; init; }
#endif
        public string? Id { get; init; }
        public string? LocalizedTitle { get; init; }
        public string? LocalizedDescription { get; init; }
        public string? LocalizedPrice { get; init; }
        public string? CurrencyCode { get; init; }
        public string? CurrencySymbol { get; init; }

        public long MicrosPrice { get; init; }
        public Period? SubscriptionPeriod { get; init; }
        public Period? FreeTrialPeriod { get; init; }
    }
}
