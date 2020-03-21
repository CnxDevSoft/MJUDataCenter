using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class ResearcherGroup
    {
        public int ResearcherGroupId { get; set; }
        public int? ResearcherId { get; set; }
        public int? PersonGroupId { get; set; }
    }
}
