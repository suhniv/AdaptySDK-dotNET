using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace Plugin.Adapty
{
    public static partial class Utils
    {
        private static readonly IDictionary<string, string> CurrencyMap;

        static Utils()
        {
            CurrencyMap = CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture)
                .Select(culture =>
                {
                    try
                    {
                        return new RegionInfo(culture.Name);
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(ri => ri != null)
                .GroupBy(ri => ri.ISOCurrencySymbol)
                .ToDictionary(x => x.Key.ToLower(), x => x.First().CurrencySymbol);
        }

        public static bool TryGetCurrencySymbol(this string isoCurrencySymbol, out string symbol)
        {
            return CurrencyMap.TryGetValue($"{isoCurrencySymbol?.ToLower()}", out symbol);
        }

        public static DateTime Iso8601ToDateTime(this string isoString) =>
            DateTime.Parse(isoString, null, DateTimeStyles.RoundtripKind);

        public static TimeSpan Iso8601ToTimeSpan(this string isoString) => string.IsNullOrEmpty(isoString) ? TimeSpan.Zero :
            XmlConvert.ToTimeSpan(isoString);
    }
}
