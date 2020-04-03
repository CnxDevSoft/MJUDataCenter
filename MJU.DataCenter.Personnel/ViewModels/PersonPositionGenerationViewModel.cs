using System;
using System.Collections.Generic;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class PersonPostionGenertionDataSourceModel
    {
        public string PersonGenertionName { get; set; }
        public List<PersonnelDataSourceViewModel> Person { get; set; }
    }

    public class PersonPostionGenertionDataTableModel
    {
        public string PersonGenertionName { get; set; }
        public int Person { get; set; }
    }

    public class PersonPostionGenertionViewModel
    {
        public string PersionPostionName { get; set; }
        public List<PersonPostionGenertionDataTableModel> PersonPostionGeneration { get; set; }
    }
    public class PersonPostionGenertionDataSourceViewModel
    {
        public string PersionPostionName { get; set; }
        public List<PersonPostionGenertionDataSourceModel> PersonPostionGeneration { get; set; }
    }
}
