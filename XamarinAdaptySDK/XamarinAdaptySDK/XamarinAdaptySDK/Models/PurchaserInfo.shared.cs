using System.Collections.Generic;

namespace XamarinAdaptySDK.Models
{
    public record PurchaserInfo
    {
        public string? ProfileId { get; init; }
        public string? CustomerUserId { get; init; }
        public IDictionary<string, PaidAccessLevelInfo>? PaidAccessLevels { get; init; }
        public IDictionary<string, Subscription>? Subscriptions { get; init; }
        public IDictionary<string, NonSubscription[]>? NonSubscriptions { get; init; }
    }
}