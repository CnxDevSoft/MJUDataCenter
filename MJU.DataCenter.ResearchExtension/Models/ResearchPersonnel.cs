using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class ResearchPersonnel
    {
        public int ResearchPersonnelId { get; set; }
        public int? ResearcherId { get; set; }
        public int? ResearchId { get; set; }
        public decimal? ResearchWorkPercent { get; set; }
    }
}
