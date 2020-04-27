using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchDetailViewModel
    {
        public int ResearchId { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public string ResearchAbstarctTh { get; set; }
        public string ResearchAbstarctEn { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }
        public List<ResearchMoneyResearchDetail> ResearchMoney { get; set; }
        public List<ResearchResearcherDetail> Researcher { get; set; }
        public int ResearcherCount { get; set; }
    }

    public class ResearchMoneyResearchDetail
    {
        public int? ResearchMoney { get; set; }
        public string ResearchMoneyTypeName { get; set; }
    }

    public class ResearchResearcherDetail
    {
        public string ResearcherName { get; set; }
        public int ResearcherId { get; set; }
        public int? FacultyId { get; set; }
        public int? FacultyCode { get; set; }
        public string FacultyName { get; set; }
        public int ResearchGroupId { get; set; }
        public string ResearchGroupName { get; set; }
        public string CitizenId { get; set; }
    }
}
