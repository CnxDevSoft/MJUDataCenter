using System;
using System.Collections.Generic;
using System.Text;

namespace MJU.DataCenter.Core.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime StartOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }
        public static DateTime EndOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 12, 31);
        }

        public static int ToLocalYear(this int year)
        {
            return year + 543;
        }

        public static DateTime ToUtcDateTime(this DateTime? dateTime)
        {

            return dateTime != null ? dateTime.GetValueOrDefault().AddYears(-543).ToUniversalTime() : DateTime.UtcNow;
        }
        public static DateTime ToLocalDateTime(this DateTime? dateTime)
        {

            return dateTime != null ? dateTime.GetValueOrDefault().AddYears(543).ToUniversalTime() : DateTime.UtcNow;
        }

        public static int ToUtcRetiredYear(this DateTime? dateTime)
        {

            return dateTime != null ? dateTime.GetValueOrDefault().AddYears(-543).Year : DateTime.UtcNow.Year;
        }

    }
}
