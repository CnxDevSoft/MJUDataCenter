using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.SeedData
{
    public class ModelSeedData
    {
    }

    public partial class ModelSeedDataPersonnelActivity
    {
        public int PersonnelActivity { get; set; }
        public string CitizenId { get; set; }
        public string PersonnelName { get; set; }
        public int? HourQty { get; set; }
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public bool? PersonnelStatus { get; set; }
    }

    public partial class ModelSeedDataActivity
    {
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

    public class Fact
    {
        public int? FactId { get; set; }
        public string FactName { get; set; }

        public int? ActivityId { get; set; }
    }

    public partial class ActivitySeed
    {

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
