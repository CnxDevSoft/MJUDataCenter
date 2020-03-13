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

}
