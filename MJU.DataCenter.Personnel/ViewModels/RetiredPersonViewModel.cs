using MJU.DataCenter.Personnel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class RetiredPersonViewModel
    {
        public string Year { get; set; }
        public List<DcPerson> Person {get;set;}
        public List<DcPerson> RetiredPerson { get; set; }
        public List<DcPerson> PredecitionRetiredPerson { get; set; }
    }


    public class RetiredPersonDataModel
    {
        public int Person { get; set; }
        public int PersonStart { get; set; }
        public decimal RetiredPersonRate { get; set; }
        public decimal PredictionRetiredPersonRate { get; set; }
    }

    public class RetiredPersonDataTableModel
    {
        public int PersonnelId { get; set; }
        public string PersonnelName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        public string PersonnelType { get; set; }
        public string PositionType { get; set; }
        public string Position { get; set; }
        public string PositionLevel { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? RetiredDate { get; set; }
        public int? RetiredYear { get; set; }
        public string Section { get; set; }
        public string Division { get; set; }
        public string Faculty { get; set; }
    }
        
}
