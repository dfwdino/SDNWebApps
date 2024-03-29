﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SDNWebApps.Areas.GroceryList.Models.Home;
using SDNWebApps.Infrastructure;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    [Access]
    public class HomeController : Controller
    {
        SDNAppsEntities ae = new SDNAppsEntities();

        public JsonResult GetItems(bool have=false)
        {
            SDNAppsEntities e = new SDNAppsEntities();
            var results = e.Items.Where(m => m.Have==have) .Select(m => new { m.Name, m.Amount,m.Store.StoreName }).ToList();
            //var results2 = JsonConvert.SerializeObject(e.Items);  //look more into
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public JsonResult List(string term)
        {
            
            return Json(ae.Items.Where(m => m.Name.Contains(term)).Select(m => new { value = m.Name, m.ID }).OrderBy(m => m.value).DistinctBy(m => m.value), 
                    JsonRequestBehavior.AllowGet); 
        }

        public ActionResult Aindex()
        {
            return View();
        }

        public ActionResult Index(bool showAll=false,bool sortbydate=false,int? storeID = null)
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
                gitems = ae.Items.OrderBy(m => m.Name).Where(m => m.StoreID == storeID && m.Have == showAll);

            if (sortbydate)
                itemsVM.Items = gitems.OrderByDescending(m => m.LastGotten).ToList();
            else
                itemsVM.Items = gitems.OrderBy(m => m.Name).ToList();


            foreach (var tempitem in itemsVM.Items)
            {
                tempitem.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tempitem.Name.ToLower());
            }


            return View(itemsVM);
        }


    }
}
