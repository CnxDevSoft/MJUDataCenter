using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchGroupViewDataModel
    {
        public int PersonGroupId { get; set; }
        public string PersonGroupName { get; set; }
        public int ResearchId { get; set; }
        public int? ResearchCode { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }

        public List<ResearcherViewModel> Researcher { get; set; }
    }
}
