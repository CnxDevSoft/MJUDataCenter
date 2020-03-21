using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class ResearcherGroup
    {
        public int ResearchPaperGroup { get; set; }
        public int? PersonId { get; set; }
        public int? PersonGroupId { get; set; }
    }
}
