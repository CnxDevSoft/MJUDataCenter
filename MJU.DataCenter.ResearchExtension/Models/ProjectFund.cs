﻿using System;
namespace MJU.DataCenter.ResearchExtension.Models
{
    public class ProjectFund
    {
        public int FundId { get; set; }
        public int? FundCode { get; set; }
        public string Fund1 { get; set; }
        public int ProjectId { get; set; }
        public int? ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLead { get; set; }
        public int? MountCode { get; set; }
        public int? DepartmentCode { get; set; }
        public decimal? Budget { get; set; }
        public int? ProjectType { get; set; }
        public int? PlanCode { get; set; }
        public int? ActivityCode { get; set; }
        public int? StatusCode { get; set; }
    }
}
