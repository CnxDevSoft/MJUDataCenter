using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.ResearchExtension.ViewModels
{
    public class FacultyDashboard
    {
        public string FacultyData { get; set; }
        public List<FacultyData> Faculty { get; set; }
    }
    public class FacultyData
    {
        public int? FacultyId { get; set; }
        public string Faculty { get; set; }
    }
}
