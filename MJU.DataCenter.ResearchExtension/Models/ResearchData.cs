using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class ResearchData
    {
        public int ResearchData1 { get; set; }
        public int? ResearchId { get; set; }
        public int? ResearchCode { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public DateTime? StartDataResearch { get; set; }
        public DateTime? EndDateResearch { get; set; }
        public int? ResearchMoney { get; set; }
    }
}
