using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonPostion
    {
        public string PersonPosionTypeName { get; set; }
        public int Person { get; set; }
    }
    public class PersonPostionViewModel
    {
        public List<PersonPostion> PersonPostion { get; set; }
    }
}
