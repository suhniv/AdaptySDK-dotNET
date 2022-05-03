#if IOS
using PaywallModel = AdaptyBinding.PaywallModel;
#elif ANDROID
using PaywallModel = Com.Adapty.Models.PaywallModel;
#endif

namespace XamarinAdaptySDK.Models
{
    public record Paywall
    {
#if IOS || ANDROID
        public PaywallModel NativePaywall { get; init; }
#endif        
        public string? Name { get; init; }
        public string? DeveloperId { get; init; }
        public string? VariationId { get; init; }
        public Product[]? Products { get; init; }
        public string? VisualPaywall { get; init; }
        public string? AbTestName { get; init; }
        public string? CustomPayload { get; init; }
        public int Revision { get; init; }
        public bool IsPromo { get; init; }
    }
}