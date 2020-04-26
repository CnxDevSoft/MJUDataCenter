using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class ResearchData
    {
        public int ResearchId { get; set; }
        public int? ResearchCode { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public DateTime? StartDateResearch { get; set; }
        public DateTime? EndDateResearch { get; set; }
        public string AbstractTh { get; set; }
        public string AbstractEn { get; set; }
    }
}
