using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonnelGenderDataSourceViewModel
    {
        public int? GenderId { get; set; }
        public string Gender { get; set; }

        public List<PersonnelDataGenderDataSource> PersonGenderGeneration { get; set; }

    }

    public class PersonnelDataGenderDataSource
    {
        public string Generetion { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }



    }
    public class PersonnelGenderDataTableViewModel
    {
        public int? GenderId { get; set; }
        public string Gender { get; set; }

        public List<PersonnelGenderDataTable> PersonGenderGeneration { get; set; }

    }

    public class PersonnelGenderDataTable
    {
        public string Generetion { get; set; }
        public int Person { get; set; }

    }
}
