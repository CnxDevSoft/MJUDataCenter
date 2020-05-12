using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.ViewModels
{
    public class FacultyActivityViewModel
    {
        public int? ActivityId { get; set; }
        public string ActivityTh { get; set; }
        public string ActivityEn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsAllDay { get; set; }
        public int? WorkLoadQty { get; set; }
        public string Location { get; set; }
        public int? ActivityFacultyId { get; set; }
        public string ActivityFacultyName { get; set; }
        public int? ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
    }
}
