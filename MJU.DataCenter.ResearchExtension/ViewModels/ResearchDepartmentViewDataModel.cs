using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchFacultyViewDataModel
    {
        public int? FacultyId { get; set; }
        public int? FacultyCode { get; set; }
        public string FacultyName { get; set; }
        public int ResearchId { get; set; }
        public string ResearchNameEn { get; set; }
        public string ResearchNameTh { get; set; }
        public int? ResearchCode { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }
        public string CitizenId { get; set; }

        public List<ResearcherViewModel> Researcher { get; set; }
    }


}
