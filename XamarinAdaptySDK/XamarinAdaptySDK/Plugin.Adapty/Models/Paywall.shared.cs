namespace Plugin.Adapty.Models
{
    public class Paywall
    {
        public string? DeveloperId { get; set; }
        public Product[]? Products { get; set; }
        public string? CustomPayload { get; set; }
    }
}
