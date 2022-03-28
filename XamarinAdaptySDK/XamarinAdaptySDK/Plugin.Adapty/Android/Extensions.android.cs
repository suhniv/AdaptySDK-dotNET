using System;
using Product = Plugin.Adapty.Models.Product;

namespace Plugin.Adapty.Android
{
    public static class Extensions
    {
        public static Product ConvertProduct(this Com.Adapty.Api.Entity.Containers.Product nativeProduct) => new Product
        {
            NativeProduct = nativeProduct,
            Id = nativeProduct.VendorProductId,
            LocalizedTitle = nativeProduct.LocalizedTitle,
            LocalizedDescription = nativeProduct.LocalizedDescription,
            LocalizedPrice = nativeProduct.Price,
            CurrencyCode = nativeProduct.CurrencyCode,
            CurrencySymbol = nativeProduct.CurrencyCode != null && nativeProduct.CurrencyCode.TryGetCurrencySymbol(out var symbol) ? symbol : default,
            MicrosPrice = nativeProduct.SkuDetails?.PriceAmountMicros ?? 0,
            SubscriptionPeriod = nativeProduct.SubscriptionPeriod?.Unit switch
            {
                { } p when p == Com.Adapty.Api.Entity.Containers.Product.PeriodUnit.D => TimeSpan.FromDays(1) * (int)nativeProduct.SubscriptionPeriod.NumberOfUnits,
                { } p when p == Com.Adapty.Api.Entity.Containers.Product.PeriodUnit.W => TimeSpan.FromDays(7) * (int)nativeProduct.SubscriptionPeriod.NumberOfUnits,
                { } p when p == Com.Adapty.Api.Entity.Containers.Product.PeriodUnit.M => TimeSpan.FromDays(31) * (int)nativeProduct.SubscriptionPeriod.NumberOfUnits,
                { } p when p == Com.Adapty.Api.Entity.Containers.Product.PeriodUnit.Y => TimeSpan.FromDays(365) * (int)nativeProduct.SubscriptionPeriod.NumberOfUnits,
                _ => TimeSpan.Zero
            },
            FreeTrialPeriod = nativeProduct.SkuDetails?.FreeTrialPeriod?.Iso8601ToTimeSpan() ?? default
        };
    }
}
