using System;
using System.Collections.Generic;
using MJU.DataCenter.ResearchExtension.Models;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchDepartmentViewModel
    {
       public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<DcResearchDepartment> ResearchData { get; set; }
    }
    
}
