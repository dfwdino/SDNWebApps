using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SDNWebApps.Areas.GroceryList.Models.Home;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    public class HomeController : Controller
    {
        SDNAppsEntities ae = new SDNAppsEntities();
        
        public ActionResult Index(bool showAll=false,int? storeID = null)
        {
            IQueryable<Item> gitems = ae.Items;
            Item item = new Item();
            var itemsVM = new ViewItemsVM();

            if (showAll)
            {
                ViewBag.Title = "All Items";
                itemsVM.ShowAll = showAll;
            }
            else
            { 
                gitems = ae.Items.Where(m => m.Have == showAll);
                ViewBag.Title = "Need Items";
            }

            if (storeID != null)
                gitems = ae.Items.Where(m => m.StoreID == storeID && m.Have == showAll);

            itemsVM.Items = gitems.OrderBy(m => m.Name).ToList();


            foreach (var tempitem in itemsVM.Items)
            {
                tempitem.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tempitem.Name.ToLower());
            }


            return View(itemsVM);
        }


    }
}
