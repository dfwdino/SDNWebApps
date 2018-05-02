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
using SDNWebApps.Infrastructure;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    [Access]
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

            //Use this if it breaks
            //return new JsonNetResult(new
            //{
            //    success = false,
            //    error = ex.Message
            //});

            return Json("Record deleted successfully!");
        }

        [HttpPost]
        public ActionResult EditItem(ItemsViewModel ivm)
        {
            ViewBag.ItemSizeID = new SelectList(sdnApps.ItemSizes, "Id", "Size");
            var gotItem = sdnApps.Items.First(m => m.ID == ivm.ID);


            if (ivm.Price != null && ivm.SelectedItemId != null)
            {
                PriceHistory ph = new PriceHistory();

                ph.Date = DateTime.Now;
                ph.StoreID = (int)ivm.SelectedItemId;
                ph.ItemID = ivm.ID;
                ph.Price = Convert.ToDecimal(ivm.Price);

                sdnApps.PriceHistories.Add(ph);
            }

            gotItem.Amount = ivm.Amount;
            gotItem.Name = ivm.Name;
            gotItem.Price = (decimal?) ivm.Price;
            gotItem.StoreID = ivm.SelectedItemId;
            gotItem.Have = false;
            gotItem.ItemSizeID = ivm.ItemSizeID;            

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
            //ivm.ItemSizeID = gotItem.ItemSizeID;
            //ivm.ItemSize = gotItem.ItemSize;

            ivm.Prices = sdnApps.PriceHistories.Where(m => m.ItemID == itemID).OrderByDescending(m => m.Date).ToList();

            //if (gotItem.ItemSizeID != null)
                ViewBag.ItemSizeID = new SelectList(sdnApps.ItemSizes, "Id", "Size", gotItem.ItemSizeID);
            //else
            //{
            //    SelectListItem sli = new SelectListItem() {Text = "---Select Type---",Selected = true};
            //    ViewBag.ItemSizeID = new SelectList(sdnApps.ItemSizes, "Id", "Size",sli);
            //}

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

            ViewBag.ItemSizeID = new SelectList(sdnApps.ItemSizes.OrderBy(m => m.Size), "Id", "Size");

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

                //if (uploadFile != null && uploadFile.ContentLength > 0)
                //{
                //    newItem.Image = new byte[uploadFile.ContentLength];
                //    uploadFile.InputStream.Read(newItem.Image, 0, uploadFile.ContentLength);
                //}

                sdnApps.Items.Add(newItem);

            }
            else
                newItem.Have = false;
            
            
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
