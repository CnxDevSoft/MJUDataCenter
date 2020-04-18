using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchDataListViewModel
    {
        public int ResearchId { get; set; }
        public int? ResearchCode { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }
        public int? ResearchMoney { get; set; }
        public int? ResearchMoneyTypeId { get; set; }
        public string MoneyTypeName { get; set; }

        public List<ResearcherData> Researcher { get; set; }
    }

    public class ResearcherData
    {
        public int? ResearcherId { get; set; }

        public string ResearcherName { get; set; }
        public string CitizenId { get; set; }
    }
}
