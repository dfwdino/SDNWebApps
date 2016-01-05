using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using SDNWebApps.Areas.GroceryList.Models.Home;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    public class ItemsController : Controller
    {
        SDNAppsEntities sdnApps = new SDNAppsEntities();

        [HttpPost]
        public JsonResult GotItem(int itemID, bool haveItem = false)
        {

            var gotItem = sdnApps.Items.First(m => m.ID == itemID);

            gotItem.LastGotten = DateTime.Now.Date;

            gotItem.Have = haveItem;
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");
        }

        [HttpPost]
        public ActionResult EditItem(ItemsViewModel ivm)
        {

            var gotItem = sdnApps.Items.First(m => m.ID == ivm.ID);

            gotItem.Amount = ivm.Amount;
            gotItem.Name = ivm.Name;
            gotItem.Price = (decimal?) ivm.Price;
            gotItem.StoreID = ivm.SelectedItemId;
            gotItem.Have = false;            

            sdnApps.SaveChanges();

            return RedirectToAction("Index","Home");
        }


        public ActionResult EditItem(int itemID)
        {
            

            var gotItem = sdnApps.Items.First(m => m.ID == itemID);

            ItemsViewModel ivm = new ItemsViewModel();

            ivm.ListToUse =
                new SDNAppsEntities().Stores.OrderBy(m => m.StoreName).Select(m =>
                    new SelectListItem { Value = SqlFunctions.StringConvert((double)m.ID).Trim(), Text = m.StoreName }).ToList();

            ivm.Amount = gotItem.Amount;
            ivm.Name = gotItem.Name;
            ivm.Price = (double) gotItem.Price;
            ivm.Store = gotItem.Store;
            ivm.SelectedItemId = gotItem.StoreID;
            ivm.ID = gotItem.ID;
            

            //if (gotItem.Image != null)
            //{
            //    ivm.Image = new byte[gotItem.Image.LongLength];
            //    uploadFile.InputStream.Read(gotItem.Image, 0, gotItem.ContentLength);
            //    ivm.Image = gotItem.Image;
            //}


            return View(ivm);
        }

        public ActionResult AddItem(string item)
    {
        var newItem = new Models.Home.ItemsViewModel();

        if (!item.IsNullOrWhiteSpace())
            ViewBag.Item = item + " was added.";

        newItem.ListToUse =
            new SDNAppsEntities().Stores.OrderBy(m => m.StoreName).Select(m =>
                new SelectListItem { Value = SqlFunctions.StringConvert((double)m.ID).Trim(), Text = m.StoreName }).ToList();

        return View(newItem);
    }

        [HttpPost]
        public ActionResult AddItem(HttpPostedFileBase uploadFile, ItemsViewModel itemsViewModel)
        {

            var newItem = sdnApps.Items.FirstOrDefault(m => m.Name == itemsViewModel.Name);

            if (newItem == null)
            {
                newItem = new Item
                {
                    Name = itemsViewModel.Name,
                    Price = Convert.ToDecimal(itemsViewModel.Price),
                    StoreID = itemsViewModel.SelectedItemId,
                    Have = false,
                    Amount = itemsViewModel.Amount
                };
            
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    newItem.Image = new byte[uploadFile.ContentLength];
                    uploadFile.InputStream.Read(newItem.Image, 0, uploadFile.ContentLength);
                }
            
            }
            else
                newItem.Have = false;

            sdnApps.Items.Add(newItem);
            sdnApps.SaveChanges();
            ViewBag.Title = "Got Item";
            return RedirectToAction("AddItem", new { item = itemsViewModel.Name });
            
            
        }

        [HttpPost]
        public JsonResult DeleteItem(int itemID)
    {
        var ditem = sdnApps.Items.First(m => m.ID == itemID);

        sdnApps.Items.Remove(ditem);
        sdnApps.SaveChanges();

        return Json("Record deleted successfully!");

    }
        
    }
}
