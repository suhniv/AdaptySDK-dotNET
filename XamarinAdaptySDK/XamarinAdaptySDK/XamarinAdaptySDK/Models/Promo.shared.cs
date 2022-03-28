using System;

namespace XamarinAdaptySDK.Models
{
    public record Promo
    {
        public Paywall? Paywall { get; init; }
        public DateTime? ExpiresAt { get; init; }
        public string? PromoType { get; init; }
        public string? VariationId { get; init; }
    }
}