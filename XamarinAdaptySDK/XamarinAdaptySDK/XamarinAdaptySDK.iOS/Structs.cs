using ObjCRuntime;

namespace AdaptyBinding
{
    [Native]
    public enum AdaptyErrorCode : long
    {
        None = -1,
        Unknown = 0,
        ClientInvalid = 1,
        PaymentCancelled = 2,
        PaymentInvalid = 3,
        PaymentNotAllowed = 4,
        StoreProductNotAvailable = 5,
        CloudServicePermissionDenied = 6,
        CloudServiceNetworkConnectionFailed = 7,
        CloudServiceRevoked = 8,
        PrivacyAcknowledgementRequired = 9,
        UnauthorizedRequestData = 10,
        InvalidOfferIdentifier = 11,
        InvalidSignature = 12,
        MissingOfferParams = 13,
        InvalidOfferPrice = 14,
        NoProductIDsFound = 1000,
        NoProductsFound = 1001,
        ProductRequestFailed = 1002,
        CantMakePayments = 1003,
        NoPurchasesToRestore = 1004,
        CantReadReceipt = 1005,
        ProductPurchaseFailed = 1006,
        MissingOfferSigningParams = 1007,
        FallbackPaywallsNotRequired = 1008,
        EmptyResponse = 2000,
        EmptyData = 2001,
        AuthenticationError = 2002,
        BadRequest = 2003,
        ServerError = 2004,
        Failed = 2005,
        UnableToDecode = 2006,
        MissingParam = 2007,
        InvalidProperty = 2008,
        EncodingFailed = 2009,
        MissingURL = 2010,
        AnalyticsDisabled = 3000
    }

    [Native]
    public enum AdaptyLogLevel : long
    {
        None = 0,
        Errors = 1,
        Verbose = 2,
        All = 3
    }

    [Native]
    public enum AttributionNetwork : ulong
    {
        Adjust = 0,
        Appsflyer = 1,
        Branch = 2,
        AppleSearchAds = 3,
        Custom = 4
    }

    [Native]
    public enum DataState : long
    {
        Cached = 0,
        Synced = 1
    }

    [Native]
    public enum Gender : long
    {
        Female = 0,
        Male = 1,
        Other = 2
    }

    [Native]
    public enum PaymentMode : ulong
    {
        PayAsYouGo = 0,
        PayUpFront = 1,
        FreeTrial = 2,
        Unknown = 3
    }

    [Native]
    public enum PeriodUnit : ulong
    {
        Day = 0,
        Week = 1,
        Month = 2,
        Year = 3,
        Unknown = 4
    }
}