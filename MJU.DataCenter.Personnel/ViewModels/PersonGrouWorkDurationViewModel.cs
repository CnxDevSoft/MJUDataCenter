using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{

    public class PersonGroupWorkDurationDataTableModel
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public List<PersonGroupWorkDurationDataTable> PersonGroupWorkDuration { get; set; }
    }
    public class PersonGroupWorkDurationDataTable
    {
        public string WorkDuration { get; set; }
        public int Person { get; set; }
    }

    public class PersonGroupWorkDurationDataSourceModel
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public List<PersonGroupWorkDurationDataSource> PersonGroupWorkDuration { get; set; }
    }
    public class PersonGroupWorkDurationDataSource
    {
        public string WorkDuration { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }
}
