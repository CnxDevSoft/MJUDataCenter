using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class DcResearchPaper
    {
        public int PaperId { get; set; }
        public int? Weigth { get; set; }
        public string ActicleNameTh { get; set; }
        public string ActicleNameEng { get; set; }
        public DateTime? PrintingDate { get; set; }
        public int? MagId { get; set; }
        public string MagazineName { get; set; }
        public int? MagazineVolum { get; set; }
        public int ResearchId { get; set; }
    }
}
