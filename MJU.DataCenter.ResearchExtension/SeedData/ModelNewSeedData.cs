using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.SeedData
{
    public class ModelNewSeedData
    {
    }
    
    public class ReasearchDataModelSeed
    {
        public int? ResearchId { get; set; }
        public int? ResearchCode { get; set; }
        public string ResearchNameTH { get; set; }
        public string ResearchNameEN { get; set; }
        public DateTime? StartDateResearch { get; set; }
        public DateTime? EndDateResearch { get; set; }
        public int? ResearchMoney { get; set; }
    }
    //ReasearchData--------------------------------------------------------------------------------------------------
    public class MoneyTypeModelSeed
    {
        public int? ResearchMoneyTypeId { get; set; }
        public string ResearchMoneyTypeName { get; set; }   
    }
    //MoneyType--------------------------------------------------------------------------------------------------
    public class ReasearchMoneyTypeModelSeed
    {
        public int? ResearchId { get; set; }
        public int? ResearchMoneyTypeId { get; set; }
    }
    //MoneyType--------------------------------------------------------------------------------------------------
}
