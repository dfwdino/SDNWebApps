using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Gas.Models.Miles
{
    public class ListViewModel
    {
        public ListViewModel(List<Gallon> gallons)
        {
            Gallons = gallons;
        }


        public int ID { get; set; }

        public  int autoID { get; set; }
        //public SDNWebApps.Person Person { get; set; }

        public string PersonID { get; set; }
        public List<Gallon> Gallons { get; set; }

        public string AutoName { get; set; }

    }

    

}