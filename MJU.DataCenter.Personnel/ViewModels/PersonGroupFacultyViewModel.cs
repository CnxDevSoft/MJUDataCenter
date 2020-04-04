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
        public List<PersonFacultyPositionDataTable> PersonGrouFaculty { get; set; }
    }
    public class PersonFacultyPositionDataTable
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public int Person { get; set; }
    }

    public class PersonGroupFacultyDataSourceModel
    {
        public int? FacultyId { get; set; }
        public string Faculty { get; set; }
        public List<PersonGroupFacultyDataSource> PersonGrouFaculty { get; set; }
    }
    public class PersonGroupFacultyDataSource
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }
}
