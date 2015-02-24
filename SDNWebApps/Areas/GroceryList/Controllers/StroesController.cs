using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    public class StoresController : Controller
    {
        SDNAppsEntities sdnApps = new SDNAppsEntities();
        public ActionResult Stores()
        {
            IQueryable<Store> gitems = sdnApps.Stores.OrderBy(m => m.StoreName);


            return View(gitems);
        }

        public ActionResult AddStore()
        {
            var newStore = new Store();

            return View(newStore);
        }

        [HttpPost]
        public ActionResult AddStore(string storeName)
        {
            Store checkStore = sdnApps.Stores.FirstOrDefault(m => m.StoreName == storeName);

            if (checkStore == null)
            {
                var newStore = new Store {StoreName = storeName};

                sdnApps.Stores.Add(newStore);
                sdnApps.SaveChanges();

                return View(newStore);
            }
            else
            {
                return View(checkStore);
            }

        }

        public JsonResult DeleteStore(int itemID)
        {
            var ditem = sdnApps.Stores.First(m => m.ID == itemID);

            sdnApps.Stores.Remove(ditem);
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");

        }
    }
}
