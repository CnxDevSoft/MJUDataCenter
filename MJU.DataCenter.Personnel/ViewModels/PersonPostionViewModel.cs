using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonPostionDataTableModel
    {
        public string PersonPosionTypeId { get; set; }
        public string PersonPosionTypeName { get; set; }
        public int Person { get; set; }
    }
    public class PersonPostionDataSourceModel
    {
        public string PersonPosionTypeId { get; set; }
        public string PersonPosionTypeName { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }
}
