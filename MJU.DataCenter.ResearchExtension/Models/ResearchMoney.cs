using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class ResearchMoney
    {
        public int ResearchMoneyId { get; set; }
        public int? ResearchId { get; set; }
        public int? ResearchMoneyTypeId { get; set; }
    }
}
