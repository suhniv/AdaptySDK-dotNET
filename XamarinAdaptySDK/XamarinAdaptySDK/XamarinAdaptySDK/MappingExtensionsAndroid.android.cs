using System.Linq;
using Com.Adapty.Models;
using XamarinAdaptySDK.Models;

namespace XamarinAdaptySDK
{
    public static class MappingExtensionsAndroid
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
            Revision = paywallModel.Revision
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
            MicrosPrice = productModel.SkuDetails?.PriceAmountMicros ?? 0,
            SubscriptionPeriod = new()
            {
                Unit = productModel.SubscriptionPeriod.Unit.ToPeriodUnit()
            },
            FreeTrialPeriod = new()
            {
                Unit = productModel.FreeTrialPeriod.Unit.ToPeriodUnit()
            }
        };

        public static Models.Enums.PeriodUnit ToPeriodUnit(this PeriodUnit periodUnit) => periodUnit switch
        {
            { } x when x == PeriodUnit.D => Models.Enums.PeriodUnit.Day,
            { } x when x == PeriodUnit.W => Models.Enums.PeriodUnit.Week,
            { } x when x == PeriodUnit.M => Models.Enums.PeriodUnit.Month,
            { } x when x == PeriodUnit.Y => Models.Enums.PeriodUnit.Year,
            _ => Models.Enums.PeriodUnit.Unknown
        };
    }
}