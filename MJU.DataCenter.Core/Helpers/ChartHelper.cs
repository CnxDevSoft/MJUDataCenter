using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Core.Helpers
{
    public static class ChartHelper
    {
        private static string[] BackgroundColorSet = { "rgba(165,96,229,0.8)", "rgba(127,157,240, 0.8)", "rgba(118,119,232, 0.5)", "rgba(41, 182, 246, 0.5)", "rgba(75, 202, 219,0.5)", "rgba(214,237,154,0.5)", "rgba(114, 249, 156,0.5)" };
        private static string[] BorderColorSet = { "rgba(165,96,229,1)", "rgba(127,157,240, 1)", "rgba(118,119,232, 1)", "rgba(41, 182, 246, 0.5)", "rgba(75, 202, 219,1)", "rgba(214,237,154,1)", "rgba(114, 249, 156,1)" };

        public static string BackgroundColor(this int index)
        {
            if (index > BackgroundColorSet.Length - 1) return null;

            return BackgroundColorSet[index];
        }

        public static string BorderColor(this int index)
        {
            if (index > BackgroundColorSet.Length - 1) return null;

            return BorderColorSet[index];
        }
    }
}
