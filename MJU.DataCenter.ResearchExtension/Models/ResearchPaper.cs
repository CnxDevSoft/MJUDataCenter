using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class ResearchPaper
    {
        public int ResearchPaperId { get; set; }
        public int? ResearcherId { get; set; }
        public string PaperNameTh { get; set; }
        public string PaperNameEn { get; set; }
        public int? Weigth { get; set; }
        public DateTime? PaperCreateDate { get; set; }
        public int? MagazineId { get; set; }
        public string MagazineName { get; set; }
        public int? MagzineVolum { get; set; }
        public int? ResearchId { get; set; }
    }
}
