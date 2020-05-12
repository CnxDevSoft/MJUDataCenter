using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.ViewModels
{
    public class PersonnelFacultyActivityDataSourceModel
    {
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<PersonnelActivityViewModel> Person { get; set; }
    }

    public class PersonnelFacultyActivityDataTableModel
    {
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public int Person { get; set; }
    }
}
