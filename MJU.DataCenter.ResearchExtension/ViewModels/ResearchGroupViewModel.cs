using System;
using System.Collections.Generic;
using MJU.DataCenter.ResearchExtension.Models;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchGroupDataSourceModel
    {
        public int? PersonGroupId { get; set; }
        public string PersonGroupName { get; set; }
        public List<DcResearchGroup> ResearchData { get; set; }
    }
    public class ResearchGroupDataTableModel
    {
        public int? PersonGroupId { get; set; }
        public string PersonGroupName { get; set; }
        public int ResearchData { get; set; }
    }
}
