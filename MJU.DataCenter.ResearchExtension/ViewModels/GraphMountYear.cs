using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class MountYearViewModel
    {
        public List<MountYearType> MountYears { get; set; }

    }
    public class MountYearType
    {
        public int MountCode { get; set; }

        public int MountYear { get; set; }
    }
}
