using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchMoneyViewDataModel
    {
        public int ResearchId { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public int? ResearchCode { get; set; }
        public int? ResearchMoney { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }
        public string MoneyTypeName { get; set; }

        public List<ResearcherViewModel> Researcher { get; set; }
    }
}
