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

namespace SDNWebApps.Areas.Weight.Controllers
{
    [Access]
    public class CardioItemsController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Weight/CardioItems
        public ActionResult Index()
        {
            return View(db.CardioItems.ToList());
        }

        // GET: Weight/CardioItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardioItem cardioItem = db.CardioItems.Find(id);
            if (cardioItem == null)
            {
                return HttpNotFound();
            }
            return View(cardioItem);
        }

        // GET: Weight/CardioItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weight/CardioItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Item,CreatedDate")] CardioItem cardioItem)
        {
            if (ModelState.IsValid)
            {
                cardioItem.CreatedDate = DateTime.Now;
                db.CardioItems.Add(cardioItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cardioItem);
        }

        // GET: Weight/CardioItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardioItem cardioItem = db.CardioItems.Find(id);
            if (cardioItem == null)
            {
                return HttpNotFound();
            }
            return View(cardioItem);
        }

        // POST: Weight/CardioItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Item,CreatedDate")] CardioItem cardioItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardioItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardioItem);
        }

        // GET: Weight/CardioItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardioItem cardioItem = db.CardioItems.Find(id);
            if (cardioItem == null)
            {
                return HttpNotFound();
            }
            return View(cardioItem);
        }

        // POST: Weight/CardioItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardioItem cardioItem = db.CardioItems.Find(id);
            db.CardioItems.Remove(cardioItem);
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
