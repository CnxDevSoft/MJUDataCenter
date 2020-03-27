using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime StartOfYearDate(this string year)
        {
            var dateString = string.Format("01-01-{0}", year);
            return DateTime.Parse(dateString);
        }

        public static DateTime EndOfYearDate(this string year)
        {
            var dateString = string.Format("12-31-{0}", year);
            return DateTime.Parse(dateString);
        }
    }
}
