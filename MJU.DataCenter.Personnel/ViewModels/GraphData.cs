using System;
using System.Collections.Generic;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class GraphData
    {
        public object ViewLabel { get; set; } 
        public List<string> Label { get; set; }
        public List<GraphDataSet> GraphDataSet { get; set; }
    }
    public class GraphDataSet
    {
        public string Label { get; set; }
        public List<int> Data { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
    }


}
