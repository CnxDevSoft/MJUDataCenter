using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchDepartment
    {
       public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<ResaerchData> ResaerchData { get; set; }
    }
    public class ResaerchData
    {
        public int? ResearchId { get; set; }
        public string ResearchNameEN { get; set; }
        public string ResearchNameTH { get; set; }
    }
}
