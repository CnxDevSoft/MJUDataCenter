using System;
using System.Collections.Generic;
using MJU.DataCenter.ResearchExtension.Models;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchFacultyDataSourceModel
    {
       public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<DcResearchDepartment> ResearchData { get; set; }
    }

    public class ResearchFacultyDataTableModel
    {
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public int ResearchData { get; set; }
    }

}
