using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class DcResearchGroup
    {
        public int PersonGroupId { get; set; }
        public string PersonGroupName { get; set; }
        public int ResearcherId { get; set; }
        public int ResearchId { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
    }
}
