using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonPostionDataTableModel
    {
        public string PersonPositionTypeId { get; set; }
        public string PersonPositionTypeName { get; set; }
        public int Person { get; set; }
    }
    public class PersonPostionDataSourceModel
    {
        public string PersonPositionTypeId { get; set; }
        public string PersonPositionTypeName { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }
}
