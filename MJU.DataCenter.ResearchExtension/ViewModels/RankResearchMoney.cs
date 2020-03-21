using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class RankResearchMoney
    {
        public string RankResearchName { get; set; }
        public int? Money { get; set; }
    }
    public class RankResearchMoneyViewModel
    {
        public List<RankResearchMoney> RankResearchMoney { get; set; }
    }

}
