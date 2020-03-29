using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime ToUtcDateTime(this DateTime? dateTime)
        {

            return dateTime != null ? dateTime.GetValueOrDefault().AddYears(-543).ToUniversalTime() : DateTime.UtcNow;
        }
    }
}
