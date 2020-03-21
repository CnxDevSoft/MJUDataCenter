using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchDataViewModel
    {
        public int? MoneyTypeId { get; set; }
        public string MoneyTypeName { get; set; }
        public List<ResearchData> ResearchData { get; set; }
    }
    public class ResearchData
    {
        public int? ResearchId { get; set; }
        public string ResearchNameEN { get; set; }
        public string ResearchNameTH { get; set; }
    }
}
