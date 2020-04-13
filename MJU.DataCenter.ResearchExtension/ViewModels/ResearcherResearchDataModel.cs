using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearcherResearchDataModel
    {
        public int ResearcherId { get; set; }
        public string ResearcherName { get; set; }
        public int? DepartmentId { get; set; }
        public int? DepartmentCode { get; set; }
        public string DepartmentNameTh { get; set; }
        public string CitizenId { get; set; }
    }
}
