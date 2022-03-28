using System;
using Foundation;

namespace Plugin.Adapty
{
    public static partial class Utils
    {
        /// <summary>The NSDate from Xamarin takes a reference point form January 1, 2001, at 12:00</summary>
        /// <remarks>
        /// It also has calls for NIX reference point 1970 but appears to be problematic
        /// </remarks>
        private static readonly DateTime NsRef = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Local); // last zero is millisecond

        /// <summary>Returns the seconds interval for a DateTime from NSDate reference data of January 1, 2001</summary>
        /// <param name="dt">The DateTime to evaluate</param>
        /// <returns>The seconds since NSDate reference date</returns>
        public static double SecondsSinceNsRefenceDate(this DateTime dt)
        {
            return (dt - NsRef).TotalSeconds;
        }

        /// <summary>Convert a DateTime to NSDate</summary>
        /// <param name="dt">The DateTime to convert</param>
        /// <returns>An NSDate</returns>
        public static NSDate ToNsDate(this DateTime dt)
        {
            return NSDate.FromTimeIntervalSinceReferenceDate(dt.SecondsSinceNsRefenceDate());
        }

        /// <summary>Convert an NSDate to DateTime</summary>
        /// <param name="nsDate">The NSDate to convert</param>
        /// <returns>A DateTime</returns>
        public static DateTime ToDateTime(this NSDate nsDate)
        {
            // We loose granularity below millisecond range but that is probably ok
            return NsRef.AddSeconds(nsDate.SecondsSinceReferenceDate);
        }
    }
}
