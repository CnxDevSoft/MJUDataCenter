using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class DcResearchDepartment
    {
        public int ResearcherId { get; set; }
        public string ResearcherName { get; set; }
        public int? DepartmentId { get; set; }
        public int? DepartmentCode { get; set; }
        public string DepartmentNameTh { get; set; }
        public int ResearchId { get; set; }
        public string ResearchNameEn { get; set; }
        public string ResearchNameTh { get; set; }
        public int? ResearchMoney { get; set; }
        public DateTime? StartDataResearch { get; set; }
        public DateTime? EndDateResearch { get; set; }
    }
}
