using System;
using System.Collections.Generic;

namespace MJU.DataCenter.PersonnelActivity.Models
{
    public partial class PersonnelActivity
    {
        public int PersonnelActivityId { get; set; }
        public int? PersonnelId { get; set; }
        public int? ActivityId { get; set; }
        public string CitizenId { get; set; }
        public string PersonnelName { get; set; }
        public int? HourQty { get; set; }
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public bool? PersonnelStatus { get; set; }
    }
}
