using System;
using Foundation;
using ObjCRuntime;
using StoreKit;
using UIKit;
using WebKit;
using AdaptyBinding;
using AppTrackingTransparency;

namespace AdaptyBinding
{
	// @interface AccessLevelInfoModel : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC6Adapty20AccessLevelInfoModel")]
	[DisableDefaultCtor]
	interface AccessLevelInfoModel : INativeObject
	{
		// @property (copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; set; }

		// @property (nonatomic) BOOL isActive;
		[Export ("isActive")]
		bool IsActive { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull vendorProductId;
		[Export ("vendorProductId")]
		string VendorProductId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull store;
		[Export ("store")]
		string Store { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable activatedAt;
		[NullAllowed, Export ("activatedAt", ArgumentSemantic.Copy)]
		NSDate ActivatedAt { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable renewedAt;
		[NullAllowed, Export ("renewedAt", ArgumentSemantic.Copy)]
		NSDate RenewedAt { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable expiresAt;
		[NullAllowed, Export ("expiresAt", ArgumentSemantic.Copy)]
		NSDate ExpiresAt { get; set; }

		// @property (nonatomic) BOOL isLifetime;
		[Export ("isLifetime")]
		bool IsLifetime { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable activeIntroductoryOfferType;
		[NullAllowed, Export ("activeIntroductoryOfferType")]
		string ActiveIntroductoryOfferType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable activePromotionalOfferType;
		[NullAllowed, Export ("activePromotionalOfferType")]
		string ActivePromotionalOfferType { get; set; }

		// @property (nonatomic) BOOL willRenew;
		[Export ("willRenew")]
		bool WillRenew { get; set; }

		// @property (nonatomic) BOOL isInGracePeriod;
		[Export ("isInGracePeriod")]
		bool IsInGracePeriod { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable unsubscribedAt;
		[NullAllowed, Export ("unsubscribedAt", ArgumentSemantic.Copy)]
		NSDate UnsubscribedAt { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable billingIssueDetectedAt;
		[NullAllowed, Export ("billingIssueDetectedAt", ArgumentSemantic.Copy)]
		NSDate BillingIssueDetectedAt { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable vendorTransactionId;
		[NullAllowed, Export ("vendorTransactionId")]
		string VendorTransactionId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable vendorOriginalTransactionId;
		[NullAllowed, Export ("vendorOriginalTransactionId")]
		string VendorOriginalTransactionId { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable startsAt;
		[NullAllowed, Export ("startsAt", ArgumentSemantic.Copy)]
		NSDate StartsAt { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cancellationReason;
		[NullAllowed, Export ("cancellationReason")]
		string CancellationReason { get; set; }

		// @property (nonatomic) BOOL isRefund;
		[Export ("isRefund")]
		bool IsRefund { get; set; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface Adapty_Swift_240 (AccessLevelInfoModel)
	// [Category]
	// [BaseType(typeof(AccessLevelInfoModel))]
	// interface AccessLevelInfoModel_Adapty_Swift_240
	// {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	// 	[Export("description")] string Description { get; }
	// }

	// @interface Adapty : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty6Adapty")]
	[DisableDefaultCtor]
	interface Adapty
	{
		[Wrap("WeakDelegate"), Static]
		[NullAllowed]
		NSObject Delegate { get; set; }

		// @property (nonatomic, weak, class) id<AdaptyDelegate> _Nullable delegate;
		[Static]
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, class) enum AdaptyLogLevel logLevel;
		[Static]
		[Export ("logLevel", ArgumentSemantic.Assign)]
		AdaptyLogLevel LogLevel { get; set; }

		// @property (nonatomic, class) BOOL idfaCollectionDisabled;
		[Static]
		[Export ("idfaCollectionDisabled")]
		bool IdfaCollectionDisabled { get; set; }

		// +(void)activate:(NSString * _Nonnull)apiKey;
		[Static]
		[Export ("activate:")]
		void Activate (string apiKey);

		// +(void)activate:(NSString * _Nonnull)apiKey observerMode:(BOOL)observerMode;
		[Static]
		[Export ("activate:observerMode:")]
		void Activate (string apiKey, bool observerMode);

		// +(void)activate:(NSString * _Nonnull)apiKey customerUserId:(NSString * _Nullable)customerUserId;
		[Static]
		[Export ("activate:customerUserId:")]
		void Activate (string apiKey, [NullAllowed] string customerUserId);

		// +(void)activate:(NSString * _Nonnull)apiKey observerMode:(BOOL)observerMode customerUserId:(NSString * _Nullable)customerUserId;
		[Static]
		[Export ("activate:observerMode:customerUserId:")]
		void Activate (string apiKey, bool observerMode, [NullAllowed] string customerUserId);

		// +(void)identify:(NSString * _Nonnull)customerUserId completion:(void (^ _Nullable)(AdaptyError * _Nullable))completion;
		[Static]
		[Export ("identify:completion:")]
		void Identify (string customerUserId, [NullAllowed] Action<AdaptyError> completion);

		// +(void)updateProfileWithParams:(ProfileParameterBuilder * _Nonnull)params completion:(void (^ _Nullable)(AdaptyError * _Nullable))completion;
		[Static]
		[Export ("updateProfileWithParams:completion:")]
		void UpdateProfileWithParams (ProfileParameterBuilder @params, [NullAllowed] Action<AdaptyError> completion);

		// +(void)updateAttribution:(NSDictionary * _Nonnull)attribution source:(enum AttributionNetwork)source networkUserId:(NSString * _Nullable)networkUserId completion:(void (^ _Nullable)(AdaptyError * _Nullable))completion;
		[Static]
		[Export ("updateAttribution:source:networkUserId:completion:")]
		void UpdateAttribution (NSDictionary attribution, AttributionNetwork source, [NullAllowed] string networkUserId, [NullAllowed] Action<AdaptyError> completion);

		// +(void)getPaywallsWithForceUpdate:(BOOL)forceUpdate :(void (^ _Nonnull)(NSArray<PaywallModel *> * _Nullable, NSArray<ProductModel *> * _Nullable, AdaptyError * _Nullable))completion;
		[Static]
		[Export ("getPaywallsWithForceUpdate::")]
		void GetPaywallsWithForceUpdate (bool forceUpdate, Action<NSArray<PaywallModel>, NSArray<ProductModel>, AdaptyError> completion);

		// +(void)makePurchaseWithProduct:(ProductModel * _Nonnull)product offerId:(NSString * _Nullable)offerId completion:(void (^ _Nonnull)(PurchaserInfoModel * _Nullable, NSString * _Nullable, NSDictionary<NSString *,id> * _Nullable, ProductModel * _Nullable, AdaptyError * _Nullable))completion;
		[Static]
		[Export ("makePurchaseWithProduct:offerId:completion:")]
		void MakePurchaseWithProduct (ProductModel product, [NullAllowed] string offerId, Action<PurchaserInfoModel, NSString, NSDictionary<NSString, NSObject>, ProductModel, AdaptyError> completion);

		// +(void)restorePurchasesWithCompletion:(void (^ _Nonnull)(PurchaserInfoModel * _Nullable, NSString * _Nullable, NSDictionary<NSString *,id> * _Nullable, AdaptyError * _Nullable))completion;
		[Static]
		[Export ("restorePurchasesWithCompletion:")]
		void RestorePurchasesWithCompletion (Action<PurchaserInfoModel, NSString, NSDictionary<NSString, NSObject>, AdaptyError> completion);

		// @property (copy, nonatomic, class) NSData * _Nullable apnsToken;
		[Static]
		[NullAllowed, Export ("apnsToken", ArgumentSemantic.Copy)]
		NSData ApnsToken { get; set; }

		// @property (copy, nonatomic, class) NSString * _Nullable apnsTokenString;
		[Static]
		[NullAllowed, Export ("apnsTokenString")]
		string ApnsTokenString { get; set; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nullable customerUserId;
		[Static]
		[NullAllowed, Export ("customerUserId")]
		string CustomerUserId { get; }

		// +(void)getPurchaserInfoWithForceUpdate:(BOOL)forceUpdate :(void (^ _Nonnull)(PurchaserInfoModel * _Nullable, AdaptyError * _Nullable))completion;
		[Static]
		[Export ("getPurchaserInfoWithForceUpdate::")]
		void GetPurchaserInfoWithForceUpdate (bool forceUpdate, Action<PurchaserInfoModel, AdaptyError> completion);

		// +(void)getPromo:(void (^ _Nullable)(PromoModel * _Nullable, AdaptyError * _Nullable))completion;
		[Static]
		[Export ("getPromo:")]
		void GetPromo ([NullAllowed] Action<PromoModel, AdaptyError> completion);

		// +(void)handlePushNotification:(NSDictionary * _Nonnull)userInfo completion:(void (^ _Nonnull)(AdaptyError * _Nullable))completion;
		[Static]
		[Export ("handlePushNotification:completion:")]
		void HandlePushNotification (NSDictionary userInfo, Action<AdaptyError> completion);

		// // +(PaywallViewController * _Nonnull)showVisualPaywallFor:(PaywallModel * _Nonnull)paywall from:(UIViewController * _Nonnull)viewController delegate:(id<AdaptyVisualPaywallDelegate> _Nonnull)delegate;
		// [Static]
		// [Export ("showVisualPaywallFor:from:delegate:")]
		// PaywallViewController ShowVisualPaywallFor (PaywallModel paywall, UIViewController viewController, AdaptyVisualPaywallDelegate @delegate);
		//
		// // +(PaywallViewController * _Nonnull)getVisualPaywallFor:(PaywallModel * _Nonnull)paywall delegate:(id<AdaptyVisualPaywallDelegate> _Nonnull)delegate __attribute__((warn_unused_result("")));
		// [Static]
		// [Export ("getVisualPaywallFor:delegate:")]
		// PaywallViewController GetVisualPaywallFor (PaywallModel paywall, AdaptyVisualPaywallDelegate @delegate);
		//
		// // +(void)closeVisualPaywall:(PaywallViewController * _Nullable)paywall;
		// [Static]
		// [Export ("closeVisualPaywall:")]
		// void CloseVisualPaywall ([NullAllowed] PaywallViewController paywall);
		//
		// // +(void)setFallbackPaywalls:(NSString * _Nonnull)paywalls completion:(void (^ _Nullable)(AdaptyError * _Nullable))completion;
		// [Static]
		// [Export ("setFallbackPaywalls:completion:")]
		// void SetFallbackPaywalls (string paywalls, [NullAllowed] Action<AdaptyError> completion);
		//
		// // +(void)logShowPaywall:(PaywallModel * _Nonnull)paywall completion:(void (^ _Nullable)(AdaptyError * _Nullable))completion;
		// [Static]
		// [Export ("logShowPaywall:completion:")]
		// void LogShowPaywall (PaywallModel paywall, [NullAllowed] Action<AdaptyError> completion);

		// +(void)setExternalAnalyticsEnabled:(BOOL)enabled completion:(void (^ _Nullable)(AdaptyError * _Nullable))completion;
		[Static]
		[Export ("setExternalAnalyticsEnabled:completion:")]
		void SetExternalAnalyticsEnabled (bool enabled, [NullAllowed] Action<AdaptyError> completion);

		// +(void)setVariationId:(NSString * _Nonnull)variationId forTransactionId:(NSString * _Nonnull)transactionId completion:(void (^ _Nullable)(AdaptyError * _Nullable))completion;
		[Static]
		[Export ("setVariationId:forTransactionId:completion:")]
		void SetVariationId (string variationId, string transactionId, [NullAllowed] Action<AdaptyError> completion);

		// +(void)presentCodeRedemptionSheet;
		[Static]
		[Export ("presentCodeRedemptionSheet")]
		void PresentCodeRedemptionSheet ();

		// +(void)logout:(void (^ _Nullable)(AdaptyError * _Nullable))completion;
		[Static]
		[Export ("logout:")]
		void Logout ([NullAllowed] Action<AdaptyError> completion);
	}
	
	delegate void NestedCallbackDelegate([BlockCallback] NestedActionDelegate action);

	delegate void NestedActionDelegate(PurchaserInfoModel purchaserInfo, NSString receipt,
		NSDictionary<NSString, NSObject> validationResult, ProductModel product, NSError error);

	// @protocol AdaptyDelegate
	[Protocol(Name = "_TtP6Adapty14AdaptyDelegate_"), Model(AutoGeneratedName = true)]
	interface AdaptyDelegate
	{
		// @required -(void)didReceiveUpdatedPurchaserInfo:(PurchaserInfoModel * _Nonnull)purchaserInfo;
		[Abstract]
		[Export("didReceiveUpdatedPurchaserInfo:")]
		void DidReceiveUpdatedPurchaserInfo(PurchaserInfoModel purchaserInfo);

		// @required -(void)didReceivePromo:(PromoModel * _Nonnull)promo;
		[Abstract]
		[Export("didReceivePromo:")]
		void DidReceivePromo(PromoModel promo);

		// @optional -(void)paymentQueueWithShouldAddStorePaymentFor:(ProductModel * _Nonnull)product defermentCompletion:(void (^ _Nonnull)(void (^ _Nullable)(PurchaserInfoModel * _Nullable, NSString * _Nullable, NSDictionary<NSString *,id> * _Nullable, ProductModel * _Nullable, AdaptyError * _Nullable)))makeDeferredPurchase;
		[Export("paymentQueueWithShouldAddStorePaymentFor:defermentCompletion:")]
		void PaymentQueueWithShouldAddStorePaymentFor(ProductModel product, NestedCallbackDelegate makeDeferredPurchase);
		
		// @optional -(void)didReceivePaywallsForConfigWithPaywalls:(NSArray<PaywallModel *> * _Nonnull)paywalls;
		[Export ("didReceivePaywallsForConfigWithPaywalls:")]
		void DidReceivePaywallsForConfigWithPaywalls (PaywallModel[] paywalls);
	}

	// @interface AdaptyError : NSError
	[BaseType(typeof(NSError), Name = "_TtC6Adapty11AdaptyError")]
	interface AdaptyError : INativeObject
	{
		// @property (nonatomic) NSError * _Nullable originalError;
		[NullAllowed, Export ("originalError", ArgumentSemantic.Assign)]
		NSError OriginalError { get; set; }

		// @property (nonatomic) enum AdaptyErrorCode adaptyErrorCode;
		[Export ("adaptyErrorCode", ArgumentSemantic.Assign)]
		AdaptyErrorCode AdaptyErrorCode { get; set; }
	}

	// @interface NonSubscriptionInfoModel : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty24NonSubscriptionInfoModel")]
	[DisableDefaultCtor]
	interface NonSubscriptionInfoModel : INativeObject
	{
		// @property (copy, nonatomic) NSString * _Nonnull purchaseId;
		[Export ("purchaseId")]
		string PurchaseId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull vendorProductId;
		[Export ("vendorProductId")]
		string VendorProductId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull store;
		[Export ("store")]
		string Store { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable purchasedAt;
		[NullAllowed, Export ("purchasedAt", ArgumentSemantic.Copy)]
		NSDate PurchasedAt { get; set; }

		// @property (nonatomic) BOOL isOneTime;
		[Export ("isOneTime")]
		bool IsOneTime { get; set; }

		// @property (nonatomic) BOOL isSandbox;
		[Export ("isSandbox")]
		bool IsSandbox { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable vendorTransactionId;
		[NullAllowed, Export ("vendorTransactionId")]
		string VendorTransactionId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable vendorOriginalTransactionId;
		[NullAllowed, Export ("vendorOriginalTransactionId")]
		string VendorOriginalTransactionId { get; set; }

		// @property (nonatomic) BOOL isRefund;
		[Export ("isRefund")]
		bool IsRefund { get; set; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface Adapty_Swift_409 (NonSubscriptionInfoModel)
	// [Category]
	// [BaseType(typeof(NonSubscriptionInfoModel))]
	// interface NonSubscriptionInfoModel_Adapty_Swift_409
	// {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	// 	[Export("description")] string Description { get; }
	// }

	// @interface PaywallModel : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty12PaywallModel")]
	[DisableDefaultCtor]
	interface PaywallModel : INativeObject
	{
		// @property (copy, nonatomic) NSString * _Nonnull developerId;
		[Export ("developerId")]
		string DeveloperId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull variationId;
		[Export ("variationId")]
		string VariationId { get; set; }

		// @property (nonatomic) NSInteger revision;
		[Export ("revision")]
		nint Revision { get; set; }

		// @property (nonatomic) BOOL isPromo;
		[Export ("isPromo")]
		bool IsPromo { get; set; }

		// @property (copy, nonatomic) NSArray<ProductModel *> * _Nonnull products;
		[Export ("products", ArgumentSemantic.Copy)]
		ProductModel[] Products { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable visualPaywall;
		[NullAllowed, Export ("visualPaywall")]
		string VisualPaywall { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customPayloadString;
		[NullAllowed, Export ("customPayloadString")]
		string CustomPayloadString { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable customPayload;
		[NullAllowed, Export ("customPayload", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> CustomPayload { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable abTestName;
		[NullAllowed, Export ("abTestName")]
		string AbTestName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface Adapty_Swift_430 (PaywallModel)
	// [Category]
	// [BaseType(typeof(PaywallModel))]
	// interface PaywallModel_Adapty_Swift_430
	// {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	// 	[Export("description")] string Description { get; }
	// }

	// @interface Adapty_Swift_447 (PaywallViewController) <WKNavigationDelegate>
	// [Category]
	// [BaseType(typeof(PaywallViewController))]
	// interface PaywallViewController_Adapty_Swift_447 : IWKNavigationDelegate
	// {
	// 	// -(void)webView:(WKWebView * _Nonnull)webView decidePolicyForNavigationAction:(WKNavigationAction * _Nonnull)navigationAction decisionHandler:(void (^ _Nonnull)(WKNavigationActionPolicy))decisionHandler;
	// 	[Export("webView:decidePolicyForNavigationAction:decisionHandler:")]
	// 	void WebView(WKWebView webView, WKNavigationAction navigationAction,
	// 		Action<WKNavigationActionPolicy> decisionHandler);
	// }

	// @interface ProductDiscountModel : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty20ProductDiscountModel")]
	[DisableDefaultCtor]
	interface ProductDiscountModel
	{
		// @property (nonatomic) NSDecimal price;
		[Export ("price", ArgumentSemantic.Assign)]
		NSDecimal Price { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable identifier;
		[NullAllowed, Export ("identifier")]
		string Identifier { get; set; }

		// @property (nonatomic, strong) ProductSubscriptionPeriodModel * _Nonnull subscriptionPeriod;
		[Export ("subscriptionPeriod", ArgumentSemantic.Strong)]
		ProductSubscriptionPeriodModel SubscriptionPeriod { get; set; }

		// @property (nonatomic) NSInteger numberOfPeriods;
		[Export ("numberOfPeriods")]
		nint NumberOfPeriods { get; set; }

		// @property (nonatomic) enum PaymentMode paymentMode;
		[Export ("paymentMode", ArgumentSemantic.Assign)]
		PaymentMode PaymentMode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable localizedPrice;
		[NullAllowed, Export ("localizedPrice")]
		string LocalizedPrice { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable localizedSubscriptionPeriod;
		[NullAllowed, Export ("localizedSubscriptionPeriod")]
		string LocalizedSubscriptionPeriod { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable localizedNumberOfPeriods;
		[NullAllowed, Export ("localizedNumberOfPeriods")]
		string LocalizedNumberOfPeriods { get; set; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface Adapty_Swift_477 (ProductDiscountModel)
	// [Category]
	// [BaseType(typeof(ProductDiscountModel))]
	// interface ProductDiscountModel_Adapty_Swift_477
	// {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	// 	[Export("description")] string Description { get; }
	// }

	// @interface ProductModel : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty12ProductModel")]
	[DisableDefaultCtor]
	interface ProductModel : INativeObject
	{
		// @property (copy, nonatomic) NSString * _Nonnull vendorProductId;
		[Export ("vendorProductId")]
		string VendorProductId { get; set; }

		// @property (nonatomic) BOOL introductoryOfferEligibility;
		[Export ("introductoryOfferEligibility")]
		bool IntroductoryOfferEligibility { get; set; }

		// @property (nonatomic) BOOL promotionalOfferEligibility;
		[Export ("promotionalOfferEligibility")]
		bool PromotionalOfferEligibility { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable promotionalOfferId;
		[NullAllowed, Export ("promotionalOfferId")]
		string PromotionalOfferId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable paywallABTestName;
		[NullAllowed, Export ("paywallABTestName")]
		string PaywallABTestName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable paywallName;
		[NullAllowed, Export ("paywallName")]
		string PaywallName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull localizedDescription;
		[Export ("localizedDescription")]
		string LocalizedDescription { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull localizedTitle;
		[Export ("localizedTitle")]
		string LocalizedTitle { get; set; }

		// @property (nonatomic) NSDecimal price;
		[Export ("price", ArgumentSemantic.Assign)]
		NSDecimal Price { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currencyCode;
		[NullAllowed, Export ("currencyCode")]
		string CurrencyCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currencySymbol;
		[NullAllowed, Export ("currencySymbol")]
		string CurrencySymbol { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable regionCode;
		[NullAllowed, Export ("regionCode")]
		string RegionCode { get; set; }

		// @property (nonatomic) BOOL isFamilyShareable;
		[Export ("isFamilyShareable")]
		bool IsFamilyShareable { get; set; }

		// @property (nonatomic, strong) ProductSubscriptionPeriodModel * _Nullable subscriptionPeriod;
		[NullAllowed, Export ("subscriptionPeriod", ArgumentSemantic.Strong)]
		ProductSubscriptionPeriodModel SubscriptionPeriod { get; set; }

		// @property (nonatomic, strong) ProductDiscountModel * _Nullable introductoryDiscount;
		[NullAllowed, Export ("introductoryDiscount", ArgumentSemantic.Strong)]
		ProductDiscountModel IntroductoryDiscount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable subscriptionGroupIdentifier;
		[NullAllowed, Export ("subscriptionGroupIdentifier")]
		string SubscriptionGroupIdentifier { get; set; }

		// @property (copy, nonatomic) NSArray<ProductDiscountModel *> * _Nonnull discounts;
		[Export ("discounts", ArgumentSemantic.Copy)]
		ProductDiscountModel[] Discounts { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable localizedPrice;
		[NullAllowed, Export ("localizedPrice")]
		string LocalizedPrice { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable localizedSubscriptionPeriod;
		[NullAllowed, Export ("localizedSubscriptionPeriod")]
		string LocalizedSubscriptionPeriod { get; set; }

		// @property (nonatomic, strong) SKProduct * _Nullable skProduct;
		[NullAllowed, Export ("skProduct", ArgumentSemantic.Strong)]
		SKProduct SkProduct { get; set; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface Adapty_Swift_516 (ProductModel)
	// [Category]
	// [BaseType(typeof(ProductModel))]
	// interface ProductModel_Adapty_Swift_516
	// {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	// 	[Export("description")] string Description { get; }
	// }

	// @interface ProductSubscriptionPeriodModel : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty30ProductSubscriptionPeriodModel")]
	[DisableDefaultCtor]
	interface ProductSubscriptionPeriodModel
	{
		// @property (nonatomic) enum PeriodUnit unit;
		[Export ("unit", ArgumentSemantic.Assign)]
		PeriodUnit Unit { get; set; }

		// @property (nonatomic) NSInteger numberOfUnits;
		[Export ("numberOfUnits")]
		nint NumberOfUnits { get; set; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface Adapty_Swift_531 (ProductSubscriptionPeriodModel)
	// [Category]
	// [BaseType(typeof(ProductSubscriptionPeriodModel))]
	// interface ProductSubscriptionPeriodModel_Adapty_Swift_531
	// {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	// 	[Export("description")] string Description { get; }
	// }

	// @interface ProfileParameterBuilder : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty23ProfileParameterBuilder")]
	interface ProfileParameterBuilder
	{
		// -(instancetype _Nonnull)withEmail:(NSString * _Nonnull)email __attribute__((warn_unused_result("")));
		[Export ("withEmail:")]
		ProfileParameterBuilder WithEmail (string email);

		// -(instancetype _Nonnull)withPhoneNumber:(NSString * _Nonnull)phoneNumber __attribute__((warn_unused_result("")));
		[Export ("withPhoneNumber:")]
		ProfileParameterBuilder WithPhoneNumber (string phoneNumber);

		// -(instancetype _Nonnull)withFacebookUserId:(NSString * _Nonnull)facebookUserId __attribute__((warn_unused_result("")));
		[Export ("withFacebookUserId:")]
		ProfileParameterBuilder WithFacebookUserId (string facebookUserId);

		// -(instancetype _Nonnull)withFacebookAnonymousId:(NSString * _Nonnull)facebookAnonymousId __attribute__((warn_unused_result("")));
		[Export ("withFacebookAnonymousId:")]
		ProfileParameterBuilder WithFacebookAnonymousId (string facebookAnonymousId);

		// -(instancetype _Nonnull)withAmplitudeUserId:(NSString * _Nonnull)amplitudeUserId __attribute__((warn_unused_result("")));
		[Export ("withAmplitudeUserId:")]
		ProfileParameterBuilder WithAmplitudeUserId (string amplitudeUserId);

		// -(instancetype _Nonnull)withAmplitudeDeviceId:(NSString * _Nonnull)amplitudeDeviceId __attribute__((warn_unused_result("")));
		[Export ("withAmplitudeDeviceId:")]
		ProfileParameterBuilder WithAmplitudeDeviceId (string amplitudeDeviceId);

		// -(instancetype _Nonnull)withMixpanelUserId:(NSString * _Nonnull)mixpanelUserId __attribute__((warn_unused_result("")));
		[Export ("withMixpanelUserId:")]
		ProfileParameterBuilder WithMixpanelUserId (string mixpanelUserId);

		// -(instancetype _Nonnull)withAppmetricaProfileId:(NSString * _Nonnull)appmetricaProfileId __attribute__((warn_unused_result("")));
		[Export ("withAppmetricaProfileId:")]
		ProfileParameterBuilder WithAppmetricaProfileId (string appmetricaProfileId);

		// -(instancetype _Nonnull)withAppmetricaDeviceId:(NSString * _Nonnull)appmetricaDeviceId __attribute__((warn_unused_result("")));
		[Export ("withAppmetricaDeviceId:")]
		ProfileParameterBuilder WithAppmetricaDeviceId (string appmetricaDeviceId);

		// -(instancetype _Nonnull)withFirstName:(NSString * _Nonnull)firstName __attribute__((warn_unused_result("")));
		[Export ("withFirstName:")]
		ProfileParameterBuilder WithFirstName (string firstName);

		// -(instancetype _Nonnull)withLastName:(NSString * _Nonnull)lastName __attribute__((warn_unused_result("")));
		[Export ("withLastName:")]
		ProfileParameterBuilder WithLastName (string lastName);

		// -(instancetype _Nonnull)withGender:(enum Gender)gender __attribute__((warn_unused_result("")));
		[Export ("withGender:")]
		ProfileParameterBuilder WithGender (Gender gender);

		// -(instancetype _Nonnull)withBirthday:(NSDate * _Nonnull)birthday __attribute__((warn_unused_result("")));
		[Export ("withBirthday:")]
		ProfileParameterBuilder WithBirthday (NSDate birthday);

		// -(instancetype _Nonnull)withCustomAttributes:(NSDictionary<NSString *,id> * _Nonnull)customAttributes __attribute__((warn_unused_result("")));
		[Export ("withCustomAttributes:")]
		ProfileParameterBuilder WithCustomAttributes (NSDictionary<NSString, NSObject> customAttributes);

		// -(instancetype _Nonnull)withAppTrackingTransparencyStatus:(enum ATTrackingManagerAuthorizationStatus)appTrackingTransparencyStatus __attribute__((warn_unused_result(""))) __attribute__((availability(macos, introduced=11.0))) __attribute__((availability(ios, introduced=14)));
		[Mac (11,0), iOS (14,0)]
		[Export ("withAppTrackingTransparencyStatus:")]
		ProfileParameterBuilder WithAppTrackingTransparencyStatus (ATTrackingManagerAuthorizationStatus appTrackingTransparencyStatus);
	}

	// @interface PromoModel : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty10PromoModel")]
	[DisableDefaultCtor]
	interface PromoModel
	{
		// @property (copy, nonatomic) NSString * _Nonnull promoType;
		[Export ("promoType")]
		string PromoType { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull variationId;
		[Export ("variationId")]
		string VariationId { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable expiresAt;
		[NullAllowed, Export ("expiresAt", ArgumentSemantic.Copy)]
		NSDate ExpiresAt { get; set; }

		// @property (nonatomic, strong) PaywallModel * _Nullable paywall;
		[NullAllowed, Export ("paywall", ArgumentSemantic.Strong)]
		PaywallModel Paywall { get; set; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface Adapty_Swift_568 (PromoModel)
	// [Category]
	// [BaseType(typeof(PromoModel))]
	// interface PromoModel_Adapty_Swift_568
	// {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	// 	[Export("description")] string Description { get; }
	// }

	// @interface PurchaserInfoModel : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty18PurchaserInfoModel")]
	[DisableDefaultCtor]
	interface PurchaserInfoModel
	{
		// @property (copy, nonatomic) NSString * _Nonnull profileId;
		[Export ("profileId")]
		string ProfileId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customerUserId;
		[NullAllowed, Export ("customerUserId")]
		string CustomerUserId { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,AccessLevelInfoModel *> * _Nonnull accessLevels;
		[Export ("accessLevels", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AccessLevels { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,SubscriptionInfoModel *> * _Nonnull subscriptions;
		[Export ("subscriptions", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Subscriptions { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSArray<NonSubscriptionInfoModel *> *> * _Nonnull nonSubscriptions;
		[Export ("nonSubscriptions", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> NonSubscriptions { get; set; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface Adapty_Swift_586 (PurchaserInfoModel)
	// [Category]
	// [BaseType(typeof(PurchaserInfoModel))]
	// interface PurchaserInfoModel_Adapty_Swift_586
	// {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	// 	[Export("description")] string Description { get; }
	// }

	// @interface SubscriptionInfoModel : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Adapty21SubscriptionInfoModel")]
	[DisableDefaultCtor]
	interface SubscriptionInfoModel : INativeObject
	{
		// @property (nonatomic) BOOL isActive;
		[Export ("isActive")]
		bool IsActive { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull vendorProductId;
		[Export ("vendorProductId")]
		string VendorProductId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull store;
		[Export ("store")]
		string Store { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable activatedAt;
		[NullAllowed, Export ("activatedAt", ArgumentSemantic.Copy)]
		NSDate ActivatedAt { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable renewedAt;
		[NullAllowed, Export ("renewedAt", ArgumentSemantic.Copy)]
		NSDate RenewedAt { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable expiresAt;
		[NullAllowed, Export ("expiresAt", ArgumentSemantic.Copy)]
		NSDate ExpiresAt { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable startsAt;
		[NullAllowed, Export ("startsAt", ArgumentSemantic.Copy)]
		NSDate StartsAt { get; set; }

		// @property (nonatomic) BOOL isLifetime;
		[Export ("isLifetime")]
		bool IsLifetime { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable activeIntroductoryOfferType;
		[NullAllowed, Export ("activeIntroductoryOfferType")]
		string ActiveIntroductoryOfferType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable activePromotionalOfferType;
		[NullAllowed, Export ("activePromotionalOfferType")]
		string ActivePromotionalOfferType { get; set; }

		// @property (nonatomic) BOOL willRenew;
		[Export ("willRenew")]
		bool WillRenew { get; set; }

		// @property (nonatomic) BOOL isInGracePeriod;
		[Export ("isInGracePeriod")]
		bool IsInGracePeriod { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable unsubscribedAt;
		[NullAllowed, Export ("unsubscribedAt", ArgumentSemantic.Copy)]
		NSDate UnsubscribedAt { get; set; }

		// @property (copy, nonatomic) NSDate * _Nullable billingIssueDetectedAt;
		[NullAllowed, Export ("billingIssueDetectedAt", ArgumentSemantic.Copy)]
		NSDate BillingIssueDetectedAt { get; set; }

		// @property (nonatomic) BOOL isSandbox;
		[Export ("isSandbox")]
		bool IsSandbox { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable vendorTransactionId;
		[NullAllowed, Export ("vendorTransactionId")]
		string VendorTransactionId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable vendorOriginalTransactionId;
		[NullAllowed, Export ("vendorOriginalTransactionId")]
		string VendorOriginalTransactionId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cancellationReason;
		[NullAllowed, Export ("cancellationReason")]
		string CancellationReason { get; set; }

		// @property (nonatomic) BOOL isRefund;
		[Export ("isRefund")]
		bool IsRefund { get; set; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface Adapty_Swift_620 (SubscriptionInfoModel)
	// [Category]
	// [BaseType(typeof(SubscriptionInfoModel))]
	// interface SubscriptionInfoModel_Adapty_Swift_620
	// {
	// 	// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
	// 	[Export("description")] string Description { get; }
	// }
}
