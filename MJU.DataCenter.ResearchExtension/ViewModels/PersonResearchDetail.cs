using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class PersonResearchDetailModel
    {
        public int ResearcherId { get; set; }
        public string ResearcherName { get; set; }
        public List<PersonResearchDetail> PersonResearchDetail { get; set; }
    }
    public class PersonResearchDetail
    {
        public int ResearchId { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public int? ResearchMoney { get; set; }
        public string MoneyTypeName { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }

        public List<PersonResearch> PersonResearcher { get; set; }
    }

    public class PersonResearch
    {
        public int ResearchId { get; set; }
        public string ResearcherName { get; set; }
        public string CitizenId { get; set; }
    }
}
