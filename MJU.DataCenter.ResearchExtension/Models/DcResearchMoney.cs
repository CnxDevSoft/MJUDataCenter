using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class DcResearchMoney
    {
        public int ResearchId { get; set; }
        public string ResearchName { get; set; }
        public int? ResearchMoney { get; set; }
        public int? MoneyTypeId { get; set; }
        public string MoneyTypeName { get; set; }
        public int? ResearcherId { get; set; }
        public string ResearcherName { get; set; }
        public string ResearcherLastName { get; set; }
    }
}
