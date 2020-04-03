using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearcherDetailModel
    {
        public string ResearcherName { get; set; }
        public int ResearcherId { get; set; }
        public int? DepartmentiId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentNameTh { get; set; }
        public List<ResearchDataModel> ResearchData { get; set; }
    }

    public class ResearchDataModel
    {
        public int ResearchId { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }
        public List<ResearchMoneyModel> ResearchMoney { get; set; }
        public ResearchGroupModel ResearchGroup { get; set; }

    }

    public class ResearchMoneyModel
    {
        public string MoneyTypeName { get; set; }
        public int? ResearchMoney { get; set; }
    }

    public class ResearchGroupModel
    {
        public string ResearchGroupName { get; set; }
        public int ResearchGroupId { get; set; }
        public List<ResearcherGroupModel> ResearcherGroup { get; set; }

    }

    public class ResearcherGroupModel
    {
        public int ResearcherId { get; set; }
        public string ReseacherName { get; set; }
    }
}
