using MJU.DataCenter.ResearchExtension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class RankResearchMoneyViewModel
    {
        public int? ResearchId { get; set; }
        public string ResearchName { get; set; }
        public List<DcResearchMoney> ResearchMoney { get; set; }
    }
}
