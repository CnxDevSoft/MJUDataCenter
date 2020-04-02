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
}
