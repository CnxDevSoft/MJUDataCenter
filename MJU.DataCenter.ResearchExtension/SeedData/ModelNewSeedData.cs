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
    //ReasearchMoneyType--------------------------------------------------------------------------------------------------
    public class ResearchPersonnelMOdelSeed
    {
        public int? PersonId { get; set; }
        public int? ResearchId { get; set; }
        public int? ResearchWorkPercent { get; set; }
        public int? ResearchMoney { get; set; }
    }
    public class ResearcherModelSeed
    {
        public int? PersonId { get; set; }
        public int? CitizenId { get; set; }
        public string TitleTH { get; set; }
        public string FirstNameTH { get; set; }
        public string LastNameTH { get; set; }
        public int? DepartmentId { get; set; }
        public int? DepartmentCode { get; set; }
        public string DepartmentNameTH { get; set; }
    }

}
