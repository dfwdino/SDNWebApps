using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages.Html;
using SDNWebApps.Views;
using HtmlHelper = System.Web.Mvc.HtmlHelper;
using System.Web.Routing;

namespace SDNWebApps.Areas.GroceryList.Models.Home
{
    public class ItemsViewModel
    {
        private ItemsViewModel ivm;

        public ItemsViewModel()
        {
            
            
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Store Store { get; set; }
        public string Amount { get; set; }

        public int? SelectedItemId { get; set; }

        [DisplayName("Image")]
        public Image Image { get; set; }

        public List<System.Web.Mvc.SelectListItem> ListToUse { get; set; }
       



    }
}