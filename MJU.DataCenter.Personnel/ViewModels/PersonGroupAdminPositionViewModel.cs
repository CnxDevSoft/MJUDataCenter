using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{

    public class PersonGroupAdminPositionDataTableModel
    {
        public string AdminPositionType { get; set; }

        public List<PersonGroupAdminPositionDataTable> PersonGroupAdminPosition { get; set; }
    }
    public class PersonGroupAdminPositionDataTable
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public int Person { get; set; }
    }

    public class PersonGroupAdminPositionDataSourceModel
    {
        public string AdminPositionType { get; set; }
        public List<PersonGroupAdminPositionDataSource> PersonGroupAdminPosition { get; set; }
    }
    public class PersonGroupAdminPositionDataSource
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }
}
