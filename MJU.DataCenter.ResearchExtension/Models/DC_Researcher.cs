using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public class DC_Researcher
    {
        public int? personID { get; set; }
        public string prefixNameTH { get; set; }
        public string nameTH { get; set; }
        public string sirNameTH { get; set; }
        public int? personGroupID { get; set; }
        public int? departmentID { get; set; }
        public int? departmentCode { get; set; }
        public string departmentNameTH { get; set; }
        public int? research_id { get; set; }
        public decimal? research_work_percent { get; set; }
        public decimal? personMoney { get; set; }
    }
}
