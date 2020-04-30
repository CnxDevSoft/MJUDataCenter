using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonEducationDetailViewModel
    {
        public string CitizenId { get; set; }
        public int? EducationLevelId { get; set; }
        public string EducationLevel { get; set; }
        public string TitleEducation { get; set; }
        public string Education { get; set; }
        public string Major { get; set; }
        public string University { get; set; }
        public string CountryId { get; set; }
        public string Country { get; set; }
        public DateTime? StartEducationDate { get; set; }
        public DateTime? GraduateDate { get; set; }
    }

}
