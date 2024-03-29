﻿using System;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Baby.Models.DoneThings
{
    public class ListViewModel
    {
        public ListViewModel(int index,int item,DateTime starttime,DateTime? endtime, LiquidSize liquidsize)
        {
            Index = index;
            Item = item;
            StartTime = starttime;
            EndTime = endtime;
            LiquidSize = liquidsize;

        }

        public ListViewModel()
        {
          
        }

        public int Index { get; set; }
        public int Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public SDNWebApps.Views.Actions Actions { get; set; }
        public double? OZ { get; set; }
        public string Mood { get; set; }
        public string Notes { get; set; }

        public LiquidSize LiquidSize { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Kid { get; set; }
        

    }
}