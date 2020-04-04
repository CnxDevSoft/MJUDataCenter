using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{

    public class PersonPositionFacultyDataTableModel
    {
        public int? FacultyId { get; set; }
        public string Faculty { get; set; }
        public List<PersonPositionFacultyDataTable> PersonPositionFaculty { get; set; }
    }
    public class PersonPositionFacultyDataTable
    {
        public string PersonPosition { get; set; }
        public int Person { get; set; }
    }

    public class PersonPositionFacultyDataSourceModel
    {
        public int? FacultyId { get; set; }
        public string Faculty { get; set; }
        public List<PersonPosiotionFacultyDataSource> PersonPositionFaculty { get; set; }
    }
    public class PersonPosiotionFacultyDataSource
    {
        public string PersonPosition { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }
}
