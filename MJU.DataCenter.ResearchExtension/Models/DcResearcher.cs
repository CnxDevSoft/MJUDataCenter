using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class DcResearcher
    {
        public int PersonId { get; set; }
        public string PrefixNameTh { get; set; }
        public string NameTh { get; set; }
        public string SirNameTh { get; set; }
        public int? PersonGroupId { get; set; }
        public int? FacultyId { get; set; }
        public int? FacultyCode { get; set; }
        public string FacultyName { get; set; }
        public decimal? ResearchWorkPercent { get; set; }
        public decimal? PersonMoney { get; set; }
    }
}
