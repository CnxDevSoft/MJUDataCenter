using System;
using System.Collections.Generic;

namespace MJU.DataCenter.Personnel.ViewModels
{
        public class PersonPostionGenertion
        {
            public string PersonGenertionName { get; set; }
            public int Person { get; set; }
        }
    public class PersonPostionGenertionViewModel
    {
        public string PersionPostionName { get; set; }
        public List<PersonPostionGenertion> PersonPostionGeneration { get; set; }
    }
}
