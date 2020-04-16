using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public partial class Researcher
    {
        public int ResearcherId { get; set; }
        public string CitizenId { get; set; }
        public string TitleTh { get; set; }
        public string FirstNameTh { get; set; }
        public string LastNameTh { get; set; }
        public int? FacultyId { get; set; }
        public int? FacultyCode { get; set; }
        public string FacultyName { get; set; }
    }
}
