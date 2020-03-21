using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class DcResearchPaperPerson
    {
        public int? PaperId { get; set; }
        public int? PersonId { get; set; }
        public decimal? PaperPercent { get; set; }
        public int? PersonGroupId { get; set; }
        public string PersonGroupName { get; set; }
    }
}
