using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDNWebApps.Areas.Gas.Models.Miles
{
    public class JSONGallonsView 
    {
        public int ID { get; set; }

        public int TotalMiles { get; set; }
        public int DrivenMiles { get; set; }
        public double TotalGallons { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<System.DateTime> GasDate { get; set; }
        public Nullable<decimal> MPG { get; set; }
        public string Store { get; set; }
        public TimeSpan? EngineRunTime { get; set; }
        public string GasType { get; set; }

    }

}