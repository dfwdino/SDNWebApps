using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDNWebApps.Areas.Gas.Models.Auto
{
    public class ListViewModel
    {
        public ListViewModel(List<SDNWebApps.Views.Auto> a,SDNWebApps.Views.Person p)
        {
            Auto = a;
            Person = p;
            
        }

        public List<SDNWebApps.Views.Auto> Auto { get; set; }
        public SDNWebApps.Views.Person Person { get; set; }





    }
}