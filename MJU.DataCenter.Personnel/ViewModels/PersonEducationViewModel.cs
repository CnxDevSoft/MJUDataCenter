using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonEducationDataTableModel
    {
        public string EducationTypeId { get; set; }
        public string EducationTypeName { get; set; }
        public int Person { get; set; }

    }

    public class PersonEducationDataSourceModel
    {
        public string EducationTypeId { get; set; }
        public string EducationTypeName { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }

    }

}
