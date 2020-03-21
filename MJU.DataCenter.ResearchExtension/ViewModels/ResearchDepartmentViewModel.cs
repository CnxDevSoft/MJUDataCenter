using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchDepartmentViewModel
    {
       public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<ResearchDataDepartment> ResearchData { get; set; }
    }
    public class ResearchDataDepartment
    {
        public int? ResearchId { get; set; }
        public string ResearchNameEN { get; set; }
        public string ResearchNameTH { get; set; }
    }
}
