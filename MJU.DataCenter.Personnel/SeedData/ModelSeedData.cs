using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.SeedData
{
    public class ModelSeedData
    {
    }
    public class PersonData
    {
       public string TitleName { get; set; }
       public string TitleNameEn { get; set; }
        public int? GenderType { get; set; }
        public string Gender { get; set; }
  

    }

    public class PersonNationality
    {
        public string NationalityId { get; set; }
        public string Nationality { get; set; }
    }

    public class Address
    {
        public string HomeNumber { get; set; }
        public int? Moo { get; set; }
        public string Soi { get; set; }
        public string Street { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public int? ZipCode { get; set; }
    }
    public class Section
    {
        public int? SectionId { get; set; }
        public string SectionName { get; set; }
    }
    public class Division
    {
        public int? DivisionId { get; set; }
        public string DivisionName { get; set; }
    }
    public class Fact
    {
        public int? FactId { get; set; }
        public string FactName { get; set; }
    }
    public class AdminPosition
    {
        public int? AdminPositionId { get; set; }
        public string AdminPositionType { get; set; }
        public string AdminPositionName { get; set; }

    }
    public class Education
    {
        public int? EducationLevelId { get; set; }
        public string EducationLevel { get; set; }
        public string TitleEducation { get; set; }
        public string EducationName { get; set; }
        public string Major { get; set; }
        public string University { get; set; }
        public string CountryId { get; set; }
        public string Country { get; set; }

    }
    public class PersonnelType
    {
        public string PersonTypeId { get; set; }
        public string PersonType { get; set; }

    }
    public class PositionRank
    {
        public string PositionRankId { get; set; }
        public string PositionRankName { get; set; }

    }
    public class PositionType
    {
        public string PositionTypeId { get; set; }
        public string PositionTypeName { get; set; }

    }
    public class PositionLevel
    {
        public string PositionLevelId { get; set; }
        public string PositionLevelName { get; set; }

    }
}
