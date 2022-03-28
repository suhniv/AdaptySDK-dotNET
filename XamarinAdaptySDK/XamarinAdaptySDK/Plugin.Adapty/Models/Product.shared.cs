using System;
#if IOS
using ProductModel = AdaptyBinding.ProductModel;
#elif ANDROID
using ProductModel = Com.Adapty.Api.Entity.Containers.Product;
#endif

namespace Plugin.Adapty.Models
{
    public class Product
    {
#if IOS || ANDROID
        public ProductModel NativeProduct { get; set; }
#endif
        public string? Id { get; set; }
        public string? LocalizedTitle { get; set; }
        public string? LocalizedDescription { get; set; }
        public string? LocalizedPrice { get; set; }
        public string? CurrencyCode { get; set; }
        public string? CurrencySymbol { get; set; }

        public long MicrosPrice { get; set; }
        public TimeSpan SubscriptionPeriod { get; set; }
        public TimeSpan FreeTrialPeriod { get; set; }
    }
}
