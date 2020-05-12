using System;
using System.Collections.Generic;

namespace MJU.DataCenter.PersonnelActivity.ViewModels
{
    public class GraphData
    {
        public List<string> Label { get; set; }
        public List<GraphDataSet> GraphDataSet { get; set; }
        public List<int?>  Value { get; set; }

    }
    public class GraphDataSet
    {
        public List<string> Label { get; set; }
        public List<int> Data { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
    }

}
