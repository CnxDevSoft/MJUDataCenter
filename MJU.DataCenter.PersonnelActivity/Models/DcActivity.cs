using System;
using System.Collections.Generic;

namespace MJU.DataCenter.PersonnelActivity.Models
{
    public partial class DcActivity
    {
        public int ActivityId { get; set; }
        public string ActivityTh { get; set; }
        public string ActivityEn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsAllDay { get; set; }
        public int? WorkLoadQty { get; set; }
        public string Location { get; set; }
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public int? ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
    }
}
