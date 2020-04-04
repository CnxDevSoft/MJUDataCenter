using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{

    public class PersonGroupFacultyDataTableModel
    {
        public int? FacultyId { get; set; }
        public string Faculty { get; set; }
        public List<PersonGroupFacultyDataTable> PersonGroupFaculty { get; set; }
    }
    public class PersonGroupFacultyDataTable
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public int Person { get; set; }
    }

    public class PersonGroupFacultyDataSourceModel
    {
        public int? FacultyId { get; set; }
        public string Faculty { get; set; }
        public List<PersonGroupFacultyDataSource> PersonGroupFaculty { get; set; }
    }
    public class PersonGroupFacultyDataSource
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }
}
