using System.Collections.Generic;

namespace Plugin.Adapty.Models
{
    public class PurchaserInfo
    {
        public IDictionary<string, PaidAccessLevelInfo>? PaidAccessLevels { get; set; }
        public IDictionary<string, Subscription>? Subscriptions { get; set; }
        public IDictionary<string, NonSubscription[]>? NonSubscriptions { get; set; }
    }
}
