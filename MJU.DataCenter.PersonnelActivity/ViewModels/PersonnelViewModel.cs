using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.PersonnelActivity.ViewModels
{
    public class PersonnelViewModel
    {
        public int? PersonnelId { get; set; }
        public string PersonnelName { get; set; }
        public int? FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string CitizenId { get; set; }
    }
}
