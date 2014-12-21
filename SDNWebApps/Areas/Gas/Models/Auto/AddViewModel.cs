using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Gas.Models.Auto
{
    public class AddViewModel
    {
        public AddViewModel()
        {
            Name = string.Empty;
        }

        public AddViewModel(SDNWebApps.Views.Auto auto)
        {
            SDNAppsEntities se = new SDNAppsEntities();

            SDNWebApps.Views.Auto a = new SDNWebApps.Views.Auto();

            a.AutoName = auto.AutoName;
            a.WhosCar = PersonID;

            se.Autos.Add(auto);
            se.SaveChanges();


        }

        public List<SDNWebApps.Views.Person> Person { get; set; }
        public string AutoName { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; }
    }

   
}