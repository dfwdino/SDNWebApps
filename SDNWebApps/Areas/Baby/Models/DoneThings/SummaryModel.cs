using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDNWebApps.Areas.Baby.Models.DoneThings
{
    public class SummaryModel
    {
        public SummaryModel(DateTime itemdate, double? oz = 0, double? sleeptime = 0)
        {
            ItemDate = itemdate;
            OZ = oz;
            SleepTime = sleeptime;
        }

        public DateTime ItemDate { get; set; }
        public double? OZ { get; set; }

        public double? SleepTime { get; set; }


    }
}
