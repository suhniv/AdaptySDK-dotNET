using System.Collections.Generic;
using System.Linq;
using Com.Adapty.Api.Entity.PurchaserInfo.Model;
using Kotlin;
using Kotlin.Jvm.Functions;
using Plugin.Adapty.Models;
using Plugin.Adapty.Models.Enums;
using Object = Java.Lang.Object;

namespace Plugin.Adapty.Android.Callback
{
    public class GetPurchaserInfoCallback : KotlinCallbackWrapper<PurchaserInfo?>, IFunction3
    {
        public Object Invoke(Object p0, Object p1, Object p2)
        {
            if (p0 is PurchaserInfoModel purchaserInfoModel)
            {
                OnResult(new PurchaserInfo
                {
                    PaidAccessLevels = purchaserInfoModel.PaidAccessLevels?.ToDictionary(paidAccessLevelInfoModel => paidAccessLevelInfoModel.Key, paidAccessLevelInfoModel => new PaidAccessLevelInfo
                    {
                        //Id = paidAccessLevelInfoModel.Value.Component8(),
                        IsActive = paidAccessLevelInfoModel.Value.IsActive().BooleanValue(),
                        VendorProductId = paidAccessLevelInfoModel.Value.VendorProductId,
                        Store = paidAccessLevelInfoModel.Value.Store switch
                        {
                            Constants.AppStore => Store.AppStore,
                            Constants.PlayStore => Store.PlayStore,
                            Constants.Adapty => Store.Adapty,
                            _ => Store.Unknown
                        },
                        //ActivatedAt = paidAccessLevelInfoModel.Value.ActivatedAt?.ToDateTime(),
                        RenewedAt = paidAccessLevelInfoModel.Value.RenewedAt?.Iso8601ToDateTime(),
                        ExpiresAt = paidAccessLevelInfoModel.Value.ExpiresAt?.Iso8601ToDateTime(),
                        IsLifetime = paidAccessLevelInfoModel.Value.IsLifetime().BooleanValue(),
                        ActiveIntroductoryOfferType = paidAccessLevelInfoModel.Value.ActiveIntroductoryOfferType switch
                        {
                            Constants.FreeTrial => OfferType.FreeTrial,
                            Constants.PayAsYouGo => OfferType.PayAsYouGo,
                            Constants.PayUpFront => OfferType.PayUpFront,
                            _ => OfferType.Unknown
                        },
                        ActivePromotionalOfferType = paidAccessLevelInfoModel.Value.ActivePromotionalOfferType switch
                        {
                            Constants.FreeTrial => OfferType.FreeTrial,
                            Constants.PayAsYouGo => OfferType.PayAsYouGo,
                            Constants.PayUpFront => OfferType.PayUpFront,
                            _ => OfferType.Unknown
                        },
                        WillRenew = paidAccessLevelInfoModel.Value.WillRenew.BooleanValue(),
                        IsInGracePeriod = paidAccessLevelInfoModel.Value.IsInGracePeriod().BooleanValue(),
                        UnsubscribedAt = paidAccessLevelInfoModel.Value.UnsubscribedAt?.Iso8601ToDateTime(),
                        BillingIssueDetectedAt = paidAccessLevelInfoModel.Value.BillingIssueDetectedAt?.Iso8601ToDateTime()
                    }) ?? new Dictionary<string, PaidAccessLevelInfo>(),
                    Subscriptions = purchaserInfoModel.Subscriptions?.ToDictionary(subscription => subscription.Key, subscription => new Subscription
                    {
                        IsActive = subscription.Value.IsActive().BooleanValue(),
                        VendorProductId = subscription.Value.VendorProductId,
                        Store = subscription.Value.Store switch
                        {
                            Constants.AppStore => Store.AppStore,
                            Constants.PlayStore => Store.PlayStore,
                            Constants.Adapty => Store.Adapty,
                            _ => Store.Unknown
                        },
                        //ActivatedAt = subscription.Value.ActivatedAt?.ToDateTime(),
                        RenewedAt = subscription.Value.RenewedAt?.Iso8601ToDateTime(),
                        ExpiresAt = subscription.Value.ExpiresAt?.Iso8601ToDateTime(),
                        StartsAt = subscription.Value.StartsAt?.Iso8601ToDateTime(),
                        IsLifetime = subscription.Value.IsLifetime().BooleanValue(),
                        ActiveIntroductoryOfferType = subscription.Value.ActiveIntroductoryOfferType switch
                        {
                            Constants.FreeTrial => OfferType.FreeTrial,
                            Constants.PayAsYouGo => OfferType.PayAsYouGo,
                            Constants.PayUpFront => OfferType.PayUpFront,
                            _ => OfferType.Unknown
                        },
                        ActivePromotionalOfferType = subscription.Value.ActivePromotionalOfferType switch
                        {
                            Constants.FreeTrial => OfferType.FreeTrial,
                            Constants.PayAsYouGo => OfferType.PayAsYouGo,
                            Constants.PayUpFront => OfferType.PayUpFront,
                            _ => OfferType.Unknown
                        },
                        WillRenew = subscription.Value.WillRenew.BooleanValue(),
                        IsInGracePeriod = subscription.Value.IsInGracePeriod().BooleanValue(),
                        UnsubscribedAt = subscription.Value.UnsubscribedAt?.Iso8601ToDateTime(),
                        BillingIssueDetectedAt = subscription.Value.BillingIssueDetectedAt?.Iso8601ToDateTime(),
                        IsSandBox = subscription.Value.IsSandbox().BooleanValue(),
                        //VendorTransactionId = subscription.Value,
                        //VendorOriginalTransactionId = subscription.Value.VendorOriginalTransactionId
                    }) ?? new Dictionary<string, Subscription>(),
                    NonSubscriptions = purchaserInfoModel.NonSubscriptions?.ToDictionary(nonSubscription => nonSubscription.Key,
                        nonSubscriptions => nonSubscriptions.Value.Select(nonSubscription => new NonSubscription
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
                            PurchasedAt = nonSubscription.PurchasedAt?.Iso8601ToDateTime(),
                            IsOneTime = nonSubscription.IsOneTime().BooleanValue(),
                            IsSandBox = nonSubscription.IsSandbox().BooleanValue(),
                            //VendorTransactionId = nonSubscription.VendorTransactionId,
                            //VendorOriginalTransactionId = nonSubscription.VendorOriginalTransactionId
                        }).ToArray()) ?? new Dictionary<string, NonSubscription[]>()
                });
            }
            else
            {
                OnResult(null);
            }

            return Unit.Instance;
        }
    }
}
