using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class DcResearchData
    {
        public int ResearchId { get; set; }
        public int? ResearchRefCode { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEng { get; set; }
        public DateTime? ResearchDateStart { get; set; }
        public DateTime? ResearchDateEnd { get; set; }
        public int? ResearchMoney { get; set; }
        public int? ResearchMoneyTypeId { get; set; }
        public string MoneyName { get; set; }
    }
}
