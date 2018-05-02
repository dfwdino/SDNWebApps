using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Infrastructure;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    [Access]
    public class ItemSizesController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: GroceryList/ItemSizes
        public ActionResult Index()
        {
            return View(db.ItemSizes.ToList());
        }

        // GET: GroceryList/ItemSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSize itemSize = db.ItemSizes.Find(id);
            if (itemSize == null)
            {
                return HttpNotFound();
            }
            return View(itemSize);
        }

        // GET: GroceryList/ItemSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroceryList/ItemSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Size,IPAddress,Longitude,Latitude,CreatedOn")] ItemSize itemSize)
        {
            if (ModelState.IsValid)
            {
                itemSize.CreatedOn = DateTime.Now;
           
                db.ItemSizes.Add(itemSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemSize);
        }

        // GET: GroceryList/ItemSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSize itemSize = db.ItemSizes.Find(id);
            if (itemSize == null)
            {
                return HttpNotFound();
            }
            return View(itemSize);
        }

        // POST: GroceryList/ItemSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Size,IPAddress,Longitude,Latitude,CreatedOn")] ItemSize itemSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemSize);
        }

        // GET: GroceryList/ItemSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSize itemSize = db.ItemSizes.Find(id);
            if (itemSize == null)
            {
                return HttpNotFound();
            }
            return View(itemSize);
        }

        // POST: GroceryList/ItemSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSize itemSize = db.ItemSizes.Find(id);
            db.ItemSizes.Remove(itemSize);
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
