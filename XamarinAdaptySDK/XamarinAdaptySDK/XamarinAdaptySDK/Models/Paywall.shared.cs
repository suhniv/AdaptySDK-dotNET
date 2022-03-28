namespace XamarinAdaptySDK.Models
{
    public record Paywall
    {
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