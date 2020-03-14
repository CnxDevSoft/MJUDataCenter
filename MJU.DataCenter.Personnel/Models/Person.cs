using System;
using System.Collections.Generic;

namespace MJU.DataCenter.Personnel.Models
{
    public partial class Person
    {
        public int PersonnelId { get; set; }
        public string IdCard { get; set; }
        public string TitleName { get; set; }
        public string TitlePosition { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TitleNameEn { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public int? GenderId { get; set; }
        public string Gender { get; set; }
        public string NationId { get; set; }
        public string Nation { get; set; }
        public string HomeNumber { get; set; }
        public int? Moo { get; set; }
        public string Soi { get; set; }
        public string Street { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public int? ZipCode { get; set; }
        public string PositionCode { get; set; }
        public string PersonnelTypeId { get; set; }
        public string PersonnelType { get; set; }
        public string PositionType { get; set; }
        public string PositionTypeId { get; set; }
        public string Position { get; set; }
        public string PositionLevelId { get; set; }
        public string PositionLevel { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? RetiredDate { get; set; }
        public int? RetiredYear { get; set; }
        public int? SectionId { get; set; }
        public string Section { get; set; }
        public int? DivisionId { get; set; }
        public string Division { get; set; }
        public int? FacultyId { get; set; }
        public string Faculty { get; set; }
        public int? Salary { get; set; }
        public int? AdminPositionId { get; set; }
        public string AdminPositionType { get; set; }
        public string AdminPosition { get; set; }
        public int? EducationLevelId { get; set; }
        public string EducationLevel { get; set; }
        public string TitleEducation { get; set; }
        public string Education { get; set; }
        public string Major { get; set; }
        public string University { get; set; }
        public string CountryId { get; set; }
        public string Country { get; set; }
        public DateTime? StartEducationDate { get; set; }
        public DateTime? GraduateDate { get; set; }
    }
}
