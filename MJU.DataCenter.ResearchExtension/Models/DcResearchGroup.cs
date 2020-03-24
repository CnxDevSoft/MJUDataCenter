using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class DcResearchGroup
    {
        public int PersonGroupId { get; set; }
        public string PersonGroupName { get; set; }
        public int ResearcherId { get; set; }
        public string ResearcherName { get; set; }
        public int ResearchId { get; set; }
        public int? ResearchCode { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }
    }
}
