using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    public class PriceHistoriesController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: GroceryList/PriceHistories
        public ActionResult Index()
        {
            var priceHistories = db.PriceHistories.Include(p => p.Store).Include(p => p.Item);
            return View(priceHistories.ToList());
        }

        // GET: GroceryList/PriceHistories/Details/5
        public ActionResult PriceHistoryItem(int id)
        {
            return View(db.PriceHistories.Where(m => m.ItemID == id).ToList());
        }
        
        // GET: GroceryList/PriceHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceHistory priceHistory = db.PriceHistories.Find(id);
            if (priceHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "StoreName", priceHistory.StoreID);
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", priceHistory.ItemID);
            return View(priceHistory);
        }

        // POST: GroceryList/PriceHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StoreID,Price,Date,IPAddress,Longitude,Latitude,ItemID")] PriceHistory priceHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "StoreName", priceHistory.StoreID);
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", priceHistory.ItemID);
            return View(priceHistory);
        }

        // GET: GroceryList/PriceHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceHistory priceHistory = db.PriceHistories.Find(id);
            if (priceHistory == null)
            {
                return HttpNotFound();
            }
            return View(priceHistory);
        }

        // POST: GroceryList/PriceHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceHistory priceHistory = db.PriceHistories.Find(id);
            db.PriceHistories.Remove(priceHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
