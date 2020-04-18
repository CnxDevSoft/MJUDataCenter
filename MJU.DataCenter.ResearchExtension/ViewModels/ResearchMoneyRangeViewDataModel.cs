using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{

    public class ResearchMoneyRangeViewDataModel
    {
        public string ResearchRankMoneyName { get; set; }
        public List<DataModelReserachMoneyRange> DataResearchMoney { get; set; }
    }

    public class DataModelReserachMoneyRange
    {
        public int? FacultyId { get; set; }
        public int? FacultyCode { get; set; }
        public string FacultyName { get; set; }
        public int ResearchId { get; set; }
        public string ResearchNameTh { get; set; }
        public string ResearchNameEn { get; set; }
        public int? ResearchCode { get; set; }
        public int? ResearchMoney { get; set; }
        public DateTime? ResearchStartDate { get; set; }
        public DateTime? ResearchEndDate { get; set; }
        public string MoneyTypeName { get; set; }
        public List<RankResearchMoneyRangeDataTableModel> Researcher { get; set; }
    }
    public class RankResearchMoneyRangeDataTableModel
    {
        public int? ResearcherId { get; set; }
        public string ResearcherName { get; set; }
        public string CitizenId { get; set; }
    }
}
