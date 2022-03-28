using System;
using Plugin.Adapty.Models.Enums;

namespace Plugin.Adapty.Models
{
    public class Subscription
    {
        public bool IsActive { get; set; }
        public string? VendorProductId { get; set; }
        public Store Store { get; set; }
        public DateTime? ActivatedAt { get; set; }
        public DateTime? RenewedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? StartsAt { get; set; }
        public bool? IsLifetime { get; set; }
        public OfferType ActiveIntroductoryOfferType { get; set; }
        public OfferType ActivePromotionalOfferType { get; set; }
        public bool WillRenew { get; set; }
        public bool IsInGracePeriod { get; set; }
        public DateTime? UnsubscribedAt { get; set; }
        public DateTime? BillingIssueDetectedAt { get; set; }
        public bool IsSandBox { get; set; }
        public string? VendorTransactionId { get; set; }
        public string? VendorOriginalTransactionId { get; set; }
    }
}
