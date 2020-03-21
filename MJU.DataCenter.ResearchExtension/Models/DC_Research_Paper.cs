using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.Models
{
    public class DC_Research_Paper
    {
        public int? paper_id { get; set; }
        public int? weigth { get; set; }
        public string acticle_nameTH { get; set; }
        public string acticle_nameEng { get; set; }
        public DateTime? printing_date { get; set; }
        public int? mag_id { get; set; }
        public string magazine_name { get; set; }
        public int? magazine_volum { get; set; }
        public int? research_id { get; set; }         
    }
}
