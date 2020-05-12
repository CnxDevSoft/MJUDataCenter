using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.ViewModels
{
    public class FacultyActivityDataSourceModel
    {
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<FacultyActivityViewModel> Activity { get; set; }
    }

    public class FacultyActivityDataTableModel
    {
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public int Activity { get; set; }
    }
}
