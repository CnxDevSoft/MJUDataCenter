using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public class DC_ResearchData
    {    
        public int? research_id { get; set; }
        public int? research_ref_code { get; set; }
        public string research_name_th { get; set; }
        public string research_name_eng { get; set; }
        public DateTime? research_date_start { get; set; }
        public DateTime? research_date_end { get; set; }
        public int? research_money { get; set; }
        public int? research_money_type_id { get; set; }
        public string money_name { get; set; }
    }
}
