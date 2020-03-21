using System;
using System.Collections.Generic;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchGroupViewModel
    {
        public int? PersonGroupId { get; set; }
        public string PersonGroupName { get; set; }
        public List<ResearchDataGroup> ResearchData { get; set; }
    }
    public class ResearchDataGroup
    {
        public int ResearchId { get; set; }
        public string ResearchNameEN { get; set; }
        public string ResearchNameTH { get; set; }
    }
}
