using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonGroupPositionLevelDataTableModel
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public List<PersonGroupPositionLevelDataTable> PersonGroupPosition { get; set; }
    }
    public class PersonGroupPositionLevelDataTable
    {
        public string PositionLevelId { get; set; }
        public string PositionLevel { get; set; }
        public int Person { get; set; }
    }

    public class PersonGroupPositionLevelDataSourceModel
    {
        public string PersonGroupTypeId { get; set; }
        public string PersonGroupTypeName { get; set; }
        public List<PersonGroupPositionLevelDataSource> PersonGroupPosition { get; set; }
    }
    public class PersonGroupPositionLevelDataSource
    {
        public string PositionLevelId { get; set; }
        public string PositionLevel { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }

}
