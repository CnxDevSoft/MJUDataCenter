using System;
using System.Collections.Generic;
using MJU.DataCenter.ResearchExtension.Models;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class ResearchDataViewModel
    {
        public int? MoneyTypeId { get; set; }
        public string MoneyTypeName { get; set; }
        public List<DcResearchData> ResearchData { get; set; }
    }

}
