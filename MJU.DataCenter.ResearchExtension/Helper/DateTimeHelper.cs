using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime StartOfYearDate(this string year)
        {
            var dateString = string.Format("01/01/{0}", year);
            return DateTime.Parse(dateString).AddHours(-7);
        }

        public static DateTime EndOfYearDate(this string year)
        {
            var dateString = string.Format("31/12/{0}", year);
            return DateTime.Parse(dateString).AddHours(-7);
        }
    }
}
