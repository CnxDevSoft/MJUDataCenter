using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.SeedData
{
    public class ModelSeedData
    {
    }
    public class FundModel 
    {
        public int? FunId { get; set; }
        public int? FundCode { get; set; }
        public string Fund { get; set; }
    }
    public class ProjectModel
    {
        public int? ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLead { get; set; }
        public int? MountCode { get; set; }
        public int? DepartmentCode { get; set; }
        public int? FundCode { get; set; }
        public decimal? Budget { get; set; }
        public int? ProjectType { get; set; }
        public int? PlanCode { get; set; }
        public int? ActivityCode { get; set; }
        public int? StatusCode { get; set; }
    }
    public class YearMount
    {
        public int MountCode { get; set; }
        public string MountYear {get; set;}

    }
}
