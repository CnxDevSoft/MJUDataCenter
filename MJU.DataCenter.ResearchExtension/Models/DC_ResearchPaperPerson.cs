using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public class DC_ResearchPaperPerson
    {
        public int? paper_ID { get; set; }
        public int? personID { get; set; }
        public decimal? paperPercent { get; set; }
        public int? personGroupID { get; set; }
        public string personGroupName { get; set; }
    }
}
