using System;
using System.Collections.Generic;
using System.Linq;
using Com.Adapty.Models;
using Com.Adapty.Utils;
using Java.Interop;
using XamarinAdaptySDK.Models;
using XamarinAdaptySDK.Models.Enums;

namespace XamarinAdaptySDK
{
    public static class MappingExtensionsAndroid
    {
        public static Paywall ToPaywall(this AdaptyPaywall paywallModel) => new()
        {
            NativePaywall = paywallModel,
            DeveloperId = paywallModel.Id,
            CustomPayload = paywallModel.RemoteConfigString,
            Name = paywallModel.Name,
            AbTestName = paywallModel.AbTestName,
            //VisualPaywall = paywallModel.VisualPaywall,
            VariationId = paywallModel.VariationId,
            //IsPromo = paywallModel.IsPromo,
            Revision = paywallModel.Revision
        };

        public static Product ToProduct(this AdaptyPaywallProduct productModel) => new()
        {
            NativeProduct = productModel,
            Id = productModel.VendorProductId,
            LocalizedTitle = productModel.LocalizedTitle,
            LocalizedDescription = productModel.LocalizedDescription,
            LocalizedPrice = productModel.LocalizedPrice,
            CurrencyCode = productModel.CurrencyCode,
            CurrencySymbol = productModel.CurrencySymbol,
            MicrosPrice = productModel.SkuDetails?.PriceAmountMicros ?? 0,
            SubscriptionPeriod = productModel.SubscriptionPeriod?.Unit?.ToPeriodUnit() is { } subscriptionPeriodUnit
                ? new Period
                {
                    Unit = subscriptionPeriodUnit,
                    NumberOfUnits = productModel.SubscriptionPeriod.NumberOfUnits
                }
                : null,
            FreeTrialPeriod = productModel.FreeTrialPeriod?.Unit?.ToPeriodUnit() is { } freeTrialPeriodUnit
                ? new Period
                {
                    Unit = freeTrialPeriodUnit,
                    NumberOfUnits = productModel.FreeTrialPeriod.NumberOfUnits
                }
                : null
        };

        public static PurchaserInfo ToPurchaserInfo(this AdaptyProfile adaptyProfile) => new()
        {
            ProfileId = adaptyProfile.ProfileId,
            CustomerUserId = adaptyProfile.CustomerUserId,
            PaidAccessLevels = adaptyProfile.AccessLevels.ToPaidAccessLevelInfos(),
            Subscriptions = adaptyProfile.Subscriptions.ToSubscriptions(),
            NonSubscriptions = adaptyProfile.NonSubscriptions.ToNonSubscriptions()
        };

        private static Dictionary<string, PaidAccessLevelInfo> ToPaidAccessLevelInfos(
            this ImmutableMap accessLevelInfos)
        {
            var result = new Dictionary<string, PaidAccessLevelInfo>();

            var iterator = accessLevelInfos.KeySet().Iterator();

            while (iterator.HasNext)
            {
                var accessLevelKey = iterator.Next();
                var acessLevel = accessLevelInfos.Get(accessLevelKey);
                result.Add(accessLevelKey.JavaCast<Java.Lang.String>().ToString(), acessLevel.JavaCast<AdaptyProfile.AccessLevel>().ToPaidAccessLevelInfo());
            }

            return result;
        }

        private static PaidAccessLevelInfo ToPaidAccessLevelInfo(this AdaptyProfile.AccessLevel accessLevel) => new()
        {
            Id = accessLevel.Id,
            IsActive = accessLevel.IsActive,
            VendorProductId = accessLevel.VendorProductId,
            Store = accessLevel.Store switch
            {
                Constants.AppStore => Store.AppStore,
                Constants.PlayStore => Store.PlayStore,
                Constants.Adapty => Store.Adapty,
                _ => Store.Unknown
            },
            ActivatedAt = DateTime.Parse(accessLevel.ActivatedAt),
            RenewedAt = DateTime.Parse(accessLevel.RenewedAt),
            ExpiresAt = DateTime.Parse(accessLevel.ExpiresAt),
            IsLifetime = accessLevel.IsLifetime,
            ActiveIntroductoryOfferType = accessLevel.ActiveIntroductoryOfferType switch
            {
                Constants.FreeTrial => OfferType.FreeTrial,
                Constants.PayAsYouGo => OfferType.PayAsYouGo,
                Constants.PayUpFront => OfferType.PayUpFront,
                _ => OfferType.Unknown
            },
            ActivePromotionalOfferType = accessLevel.ActivePromotionalOfferType switch
            {
                Constants.FreeTrial => OfferType.FreeTrial,
                Constants.PayAsYouGo => OfferType.PayAsYouGo,
                Constants.PayUpFront => OfferType.PayUpFront,
                _ => OfferType.Unknown
            },
            WillRenew = accessLevel.WillRenew,
            IsInGracePeriod = accessLevel.IsInGracePeriod,
            UnsubscribedAt = DateTime.Parse(accessLevel.UnsubscribedAt),
            BillingIssueDetectedAt = DateTime.Parse(accessLevel.BillingIssueDetectedAt)
        };

        private static Dictionary<string, Subscription> ToSubscriptions(this ImmutableMap subscriptions)
        {
            var result = new Dictionary<string, Subscription>();

            var iterator = subscriptions.KeySet().Iterator();

            while (iterator.HasNext)
            {
                var accessLevelKey = iterator.Next();
                var acessLevel = subscriptions.Get(accessLevelKey);
                result.Add(accessLevelKey.JavaCast<Java.Lang.String>().ToString(), acessLevel.JavaCast<AdaptyProfile.Subscription>().ToSubscription());
            }

            return result;
        }

        private static Subscription ToSubscription(this AdaptyProfile.Subscription subscription) => new()
        {
            IsActive = subscription.IsActive,
            VendorProductId = subscription.VendorProductId,
            Store = subscription.Store switch
            {
                Constants.AppStore => Store.AppStore,
                Constants.PlayStore => Store.PlayStore,
                Constants.Adapty => Store.Adapty,
                _ => Store.Unknown
            },
            ActivatedAt = DateTime.Parse(subscription.ActivatedAt),
            RenewedAt = DateTime.Parse(subscription.RenewedAt),
            ExpiresAt = DateTime.Parse(subscription.ExpiresAt),
            StartsAt = DateTime.Parse(subscription.StartsAt),
            IsLifetime = subscription.IsLifetime,
            ActiveIntroductoryOfferType = subscription.ActiveIntroductoryOfferType switch
            {
                Constants.FreeTrial => OfferType.FreeTrial,
                Constants.PayAsYouGo => OfferType.PayAsYouGo,
                Constants.PayUpFront => OfferType.PayUpFront,
                _ => OfferType.Unknown
            },
            ActivePromotionalOfferType = subscription.ActivePromotionalOfferType switch
            {
                Constants.FreeTrial => OfferType.FreeTrial,
                Constants.PayAsYouGo => OfferType.PayAsYouGo,
                Constants.PayUpFront => OfferType.PayUpFront,
                _ => OfferType.Unknown
            },
            WillRenew = subscription.WillRenew,
            IsInGracePeriod = subscription.IsInGracePeriod,
            UnsubscribedAt = DateTime.Parse(subscription.UnsubscribedAt),
            BillingIssueDetectedAt = DateTime.Parse(subscription.BillingIssueDetectedAt),
            IsSandBox = subscription.IsSandbox,
            CancellationReason = subscription.CancellationReason,
            VendorTransactionId = subscription.VendorTransactionId,
            VendorOriginalTransactionId = subscription.VendorOriginalTransactionId
        };
        
        private static Dictionary<string, NonSubscription[]> ToNonSubscriptions(this ImmutableMap nonSubscriptions)
        {
            var result = new Dictionary<string, NonSubscription[]>();

            var iterator = nonSubscriptions.KeySet().Iterator();

            while (iterator.HasNext)
            {
                var accessLevelKey = iterator.Next();
                var acessLevel = nonSubscriptions.Get(accessLevelKey);
                result.Add(accessLevelKey.JavaCast<Java.Lang.String>().ToString(), nonSubscriptions.JavaCast<ImmutableList>().ToNonSubscriptionEnumerable().ToArray());
            }

            return result;
        }
        
        private static IEnumerable<NonSubscription> ToNonSubscriptionEnumerable(this ImmutableList nonSubscriptions)
        {
            var iterator = nonSubscriptions.Iterator();

            while (iterator.HasNext)
            {
                yield return iterator.Next().JavaCast<AdaptyProfile.NonSubscription>().ToNonSubscription();
            }
        }

        private static NonSubscription ToNonSubscription(this AdaptyProfile.NonSubscription nonSubscription) => new()
        {
            PurchaseId = nonSubscription.PurchaseId,
            VendorProductId = nonSubscription.VendorProductId,
            Store = nonSubscription.Store switch
            {
                Constants.AppStore => Store.AppStore,
                Constants.PlayStore => Store.PlayStore,
                Constants.Adapty => Store.Adapty,
                _ => Store.Unknown
            },
            PurchasedAt = DateTime.Parse(nonSubscription.PurchasedAt),
            IsOneTime = nonSubscription.IsOneTime,
            IsSandBox = nonSubscription.IsSandbox,
            IsRefund = nonSubscription.IsRefund,
            VendorTransactionId = nonSubscription.VendorTransactionId,
            VendorOriginalTransactionId = nonSubscription.VendorTransactionId
        };

        public static PeriodUnit ToPeriodUnit(this AdaptyPeriodUnit periodUnit) => periodUnit switch
        {
            { } x when x == AdaptyPeriodUnit.Day => Models.Enums.PeriodUnit.Day,
            { } x when x == AdaptyPeriodUnit.Week => Models.Enums.PeriodUnit.Week,
            { } x when x == AdaptyPeriodUnit.Month => Models.Enums.PeriodUnit.Month,
            { } x when x == AdaptyPeriodUnit.Year => Models.Enums.PeriodUnit.Year,
            _ => Models.Enums.PeriodUnit.Unknown
        };
    }
}