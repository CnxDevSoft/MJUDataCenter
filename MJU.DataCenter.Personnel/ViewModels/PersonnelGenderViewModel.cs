using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonnelGenderViewModel
    {
        public string Generetion { get; set; }
        public int SumGenderM { get; set; }
        public string GenderM { get; set; }
        public int SumGenderFM { get; set; }
        public string GenderFM { get; set; }
        public List<PersonnelDataGenderViewModel> PersonGenderData { get; set; }
        public List<PersonnelDataGenderViewModel> PersonGenderDataM { get; set; }
        public List<PersonnelDataGenderViewModel> PersonGenderDataFM { get; set; }
    }

    public class PersonnelDataGenderViewModel
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
        public int GenderId { get; set; }
        public string Gender { get; set; }
    }

    public class PersonnelDataGenderDataTableViewModel
    {
        public string Generetion { get; set; }  
        public string GenderM { get; set; }
        public string GenderFM { get; set; }
        public List<PersonnelDataGenderViewModel> PersonnelDataTableGender { get; set; }

    }
}
