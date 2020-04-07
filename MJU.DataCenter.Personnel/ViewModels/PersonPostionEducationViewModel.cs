using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonPostionEducationDataTableModel
    {
        public string PersonPosionTypeId { get; set; }
        public string PersonPosionTypeName { get; set; }
        public List<PersonPostionEducationDataTable> PersonPostionEducation { get; set; }
    }

    public class PersonPostionEducationDataTable
    {
        public int? EducationLevelId { get; set; }
        public string EducationLevel { get; set; }
        public int Person { get; set; }
    }

    public class PersonPostionEducationDataSourceModel
    {
        public string PersonPosionTypeId { get; set; }
        public string PersonPosionTypeName { get; set; }
        public List<PersonPostionEducationDataSource> PersonPostionEducation { get; set; }
    }

    public class PersonPostionEducationDataSource
    {
        public int? EducationLevelId { get; set; }
        public string EducationLevel { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }
}
