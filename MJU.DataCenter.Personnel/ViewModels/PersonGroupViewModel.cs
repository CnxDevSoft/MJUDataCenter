using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonGroupViewModel
    {
        public List<PersonGroup> PersonGroup { get; set; }
    }
    public class PersonGroup
    {
        public string PersonGroupTypeName { get; set; }
        public int Person { get; set; }
    }
}
