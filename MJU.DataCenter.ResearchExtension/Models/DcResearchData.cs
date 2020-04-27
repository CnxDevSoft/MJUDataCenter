using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class DcResearchData
    {
        public int ResearcherId { get; set; }
        public string ResearcherName { get; set; }
        public int? FacultyId { get; set; }
        public int? FacultyCode { get; set; }
        public string FacultyName { get; set; }
        public string CitizenId { get; set; }
        public int ResearchId { get; set; }
        public int? ResearchCode { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public string AbstractTh { get; set; }
        public string AbstractEn { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }
        public int? ResearchMoney { get; set; }
        public int? ResearchMoneyTypeId { get; set; }
        public string MoneyTypeName { get; set; }
    }
}
