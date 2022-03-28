using System;
using XamarinAdaptySDK.Models.Enums;

namespace XamarinAdaptySDK.Models
{
    public record NonSubscription
    {
        public string? PurchaseId { get; init; }
        public string? VendorProductId { get; init; }
        public Store Store { get; init; }
        public DateTime? PurchasedAt { get; init; }
        public bool IsOneTime { get; init; }
        public bool IsSandBox { get; init; }
        public bool IsRefund { get; init; }
        public string? VendorTransactionId { get; init; }
        public string? VendorOriginalTransactionId { get; init; }
    }
}
