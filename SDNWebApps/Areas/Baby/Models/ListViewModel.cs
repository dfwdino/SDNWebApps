using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Baby.Models
{
    public class ListViewModel
    {
        public ListViewModel(int index,int item,DateTime starttime,DateTime? endtime)
        {
            Index = index;
            Item = item;
            StartTime = starttime;
            EndTime = endtime;

        }

        public ListViewModel()
        {
          
        }

        public int Index { get; set; }
        public int Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Actions Actions { get; set; }
        public double? OZ { get; set; }

    }
}