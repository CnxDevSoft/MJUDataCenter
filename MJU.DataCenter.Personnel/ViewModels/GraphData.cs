using System;
using System.Collections.Generic;

namespace MJU.DataCenter.Personnel.ViewModels
{
    public class GraphData
    {
        public object ViewLabel { get; set; }
        public List<ViewData> ViewData { get; set; }
        public List<string> Label { get; set; }
        public List<GraphDataSet> GraphDataSet { get; set; }
        public bool IsSubGraphDataSet { get; set; }
    }
    public class GraphDataSet
    {
        public string Label { get; set; }
        public List<int> Data { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
    }

    public class ViewData
    {
        public int index { get; set; }
        public object ListViewData {get;set;}
    }


}
