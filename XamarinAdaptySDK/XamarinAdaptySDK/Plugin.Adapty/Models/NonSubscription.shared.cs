using System;
using Plugin.Adapty.Models.Enums;

namespace Plugin.Adapty.Models
{
    public class NonSubscription
    {
        public string? PurchaseId { get; set; }
        public string? VendorProductId { get; set; }
        public Store Store { get; set; }
        public DateTime? PurchasedAt { get; set; }
        public bool IsOneTime { get; set; }
        public bool IsSandBox { get; set; }
        public string? VendorTransactionId { get; set; }
        public string? VendorOriginalTransactionId { get; set; }
    }
}
