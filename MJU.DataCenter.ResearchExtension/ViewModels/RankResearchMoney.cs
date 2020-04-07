using MJU.DataCenter.ResearchExtension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class RankResearchMoneyDataTableModel
    {
        public int? ResearchId { get; set; }
        public string ResearchName { get; set; }
        public int ResearchMoney { get; set; }
    }

    public class RankResearchMoneyDataSourceModel
    {
        public int? ResearchId { get; set; }
        public string ResearchName { get; set; }
        public List<DcResearchMoney> ResearchMoney { get; set; }
    }

    public class RankResearchRageMoneyDataSourceModel
    {
        public string ResearchRankMoneyName { get; set; }
        public List<DataModelReserachMoney> DataResearchMoney { get; set; }
    }

    public class DataModelReserachMoney
    {
        public int ResearchId { get; set; }
        public string ResearcherName { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public int? ResearchCode { get; set; }
        public int? ResearchMoney { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }
        public string MoneyTypeName { get; set; }
        public int? ResearcherId { get; set; }
    }


}
