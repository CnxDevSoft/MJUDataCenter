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
        public string CitizenId { get; set; }
        public string TitleTH { get; set; }
        public string FirstNameTH { get; set; }
        public string LastNameTH { get; set; }
        public int? DepartmentId { get; set; }
        public int? DepartmentCode { get; set; }
        public string DepartmentNameTH { get; set; }
    }
    public class ResearchPaperGroupModelSeed
    {
           public int? PersonId { get; set; }
           public int? PersonGroupId { get; set; }
    }

    public class PersonnelGroupModelSeed
    {
        public int? PersonGroupId { get; set; }
        public string PersonGroupName { get; set; }
    }

    public class ResearcherPaperModelSeed
    {
        public int? PaperId { get; set; }
        public int? PersonId { get; set; }
        public int? PaperPercent { get; set; }
    }

    public class ResearchPaperModelSeed
    {
        public int? PaperId { get; set; }
        public string PaperNameTH { get; set; }
        public  string PaperNameEN { get; set; }
        public int? Weigth { get; set; }
        public DateTime? PaperCreateData { get; set; }
        public int? MagazineId { get; set; }
        public string MagazineName { get; set; }
        public int? MagzineVolum { get; set; }
    }
    public class Depart
    {
        public int? DepartId { get; set; }
        public int? DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }

    public class PersonnelGroup
    {
        public int? PersonGroupId { get; set; }
        public string PersonGroupName { get; set; }

    }
    public class MoneyTypeModel
    {
        public string MoneyTypeName { get; set; }

    }
    public class Abstract
    {
        public string AbstractTH { get; set; }
        public string AbstractEN { get; set; }
    }
}
