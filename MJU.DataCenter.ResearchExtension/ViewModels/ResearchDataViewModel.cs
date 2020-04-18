using System;
using System.Collections.Generic;
using MJU.DataCenter.ResearchExtension.Models;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchDataDataSourceModel
    {
        public int? MoneyTypeId { get; set; }
        public string MoneyTypeName { get; set; }
        public List<ResearchDataListViewModel> ResearchData { get; set; }
    }

    public class ResearchDataDataTableModel
    {
        public int? MoneyTypeId { get; set; }
        public string MoneyTypeName { get; set; }
        public int ResearchData { get; set; }
    }

}
