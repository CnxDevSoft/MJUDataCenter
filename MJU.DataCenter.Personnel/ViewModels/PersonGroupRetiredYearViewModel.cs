using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonGroupRetiredYearDataTableModel
    {
        public int? ReitredYear { get; set; }
        public List<PersonGroupRetiredYearDataTable> PersonGroupRetiredYear { get; set; }
    }
    public class PersonGroupRetiredYearDataTable
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public int Person { get; set; }
    }

    public class PersonGroupRetiredYearDataSourceModel
    {
        public int? ReitredYear { get; set; }
        public List<PersonGroupRetiredYearDataSource> PersonGroupRetiredYear { get; set; }
    }
    public class PersonGroupRetiredYearDataSource
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }

}
