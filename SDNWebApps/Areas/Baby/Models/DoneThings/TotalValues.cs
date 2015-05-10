using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SDNWebApps.Areas.Baby.Models.DoneThings
{
    public class TotalValues
    {
        public double FeedOz = 0;
        public double PumpedOz = 0;
        public double Teaspoons = 0;
        public TimeSpan SleepTime = new TimeSpan();


        public void ResetValues()
        {
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name.Equals("SleepTime"))
                    property.SetValue(this, new TimeSpan());
                else
                    property.SetValue(this, 0);
            }
        }
    }
}