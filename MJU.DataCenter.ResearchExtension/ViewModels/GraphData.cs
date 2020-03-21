using System;
using System.Collections.Generic;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class GraphData
    {
        public List<string> Label { get; set; }
        public List<GraphDataSet> GraphDataSet { get; set; }
    }
    public class GraphDataSet
    {
        public string Label { get; set; }
        public ViewData ViewData { get; set; }
        public List<int> Data { get; set; }
    }

    public class ViewData
    {
        public int index { get; set; }
        public object LisViewData {get;set;}
    }
}
