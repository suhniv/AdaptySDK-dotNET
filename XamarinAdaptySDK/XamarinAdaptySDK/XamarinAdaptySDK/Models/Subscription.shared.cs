using System;
using XamarinAdaptySDK.Models.Enums;

namespace XamarinAdaptySDK.Models
{
    public record Subscription
    {
        public bool IsActive { get; init; }
        public string? VendorProductId { get; init; }
        public Store Store { get; init; }
        public DateTime? ActivatedAt { get; init; }
        public DateTime? RenewedAt { get; init; }
        public DateTime? ExpiresAt { get; init; }
        public DateTime? StartsAt { get; init; }
        public bool? IsLifetime { get; init; }
        public OfferType ActiveIntroductoryOfferType { get; init; }
        public OfferType ActivePromotionalOfferType { get; init; }
        public bool WillRenew { get; init; }
        public bool IsInGracePeriod { get; init; }
        public DateTime? UnsubscribedAt { get; init; }
        public DateTime? BillingIssueDetectedAt { get; init; }
        public bool IsSandBox { get; init; }
        public string? CancellationReason { get; init; }
        public string? VendorTransactionId { get; init; }
        public string? VendorOriginalTransactionId { get; init; }
    }
}