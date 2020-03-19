using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class MoneyType
    {
        public int MoneyTypeId { get; set; }
        public int? ResearchMoneyTypeId { get; set; }
        public string ResearchMoneyTypeName { get; set; }
    }
}
