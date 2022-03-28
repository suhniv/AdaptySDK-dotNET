using XamarinAdaptySDK.Models.Enums;

namespace XamarinAdaptySDK.Models
{
    public record Period
    {
        public PeriodUnit Unit { get; init; }
        public int NumberOfUnits { get; init; }
    }
}