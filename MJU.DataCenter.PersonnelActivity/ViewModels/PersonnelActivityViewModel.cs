using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.ViewModels
{
    public class PersonnelActivityViewModel
    {
        public int PersonnelActivityId { get; set; }
        public int? PersonnelId { get; set; }
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
        public string CitizenId { get; set; }
        public string PersonnelName { get; set; }
        public int? HourQty { get; set; }
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public bool? PersonnelStatus { get; set; }
    }
}
