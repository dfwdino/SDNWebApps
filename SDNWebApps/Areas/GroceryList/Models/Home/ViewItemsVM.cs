using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using SDNWebApps.Views;
using HtmlHelper = System.Web.Mvc.HtmlHelper;
using System.Web.Routing;

namespace SDNWebApps.Areas.GroceryList.Models.Home
{
    public class ViewItemsVM
    {
        public ViewItemsVM()
        {




        }

        public List<Item> Items { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Store { get; set; }
        public bool ShowAll { get; set; }



    }
}