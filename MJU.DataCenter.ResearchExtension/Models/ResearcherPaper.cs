using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class ResearcherPaper
    {
        public int ResearcherPaperId { get; set; }
        public int? PaperId { get; set; }
        public int? PersonId { get; set; }
        public decimal? PaperPercent { get; set; }
    }
}
