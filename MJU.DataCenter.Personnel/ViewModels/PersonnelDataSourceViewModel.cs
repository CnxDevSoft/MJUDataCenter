using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonnelDataSourceViewModel
    {
        public int PersonnelId { get; set; }
        public string IdCard { get; set; }
        public string PersonName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public string Gender { get; set; }
        public string Nation { get; set; }
        public string Province { get; set; }
        public int? ZipCode { get; set; }
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
        public int? Salary { get; set; }
        public string AdminPositionType { get; set; }
        public string AdminPosition { get; set; }
        public string EducationLevel { get; set; }
        public string TitleEducation { get; set; }
        public string Education { get; set; }
        public string Major { get; set; }
        public string University { get; set; }
        public string Country { get; set; }
        public DateTime? StartEducationDate { get; set; }
        public DateTime? GraduateDate { get; set; }
    }
}
