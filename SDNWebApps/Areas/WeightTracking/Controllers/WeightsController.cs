using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.WeightTracking.Controllers
{
    public class WeightsController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: WeightTracking/Weights
        public ActionResult Index()
        {
            var weights = db.Weights.Include(w => w.Size);
            return View(weights.ToList());
        }

        // GET: WeightTracking/Weights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weight weight = db.Weights.Find(id);
            if (weight == null)
            {
                return HttpNotFound();
            }
            return View(weight);
        }

        // GET: WeightTracking/Weights/Create
        public ActionResult Create()
        {
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Notes");
            return View();
        }

        // POST: WeightTracking/Weights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeightID,SizeID,Pound,CreatedOn,UpdatedOn,IPAddress,Broswer,StatusDate")] Weight weight)
        {
            if (ModelState.IsValid)
            {
                db.Weights.Add(weight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Notes", weight.SizeID);
            return View(weight);
        }

        // GET: WeightTracking/Weights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weight weight = db.Weights.Find(id);
            if (weight == null)
            {
                return HttpNotFound();
            }
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Notes", weight.SizeID);
            return View(weight);
        }

        // POST: WeightTracking/Weights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeightID,SizeID,Pound,CreatedOn,UpdatedOn,IPAddress,Broswer,StatusDate")] Weight weight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "Notes", weight.SizeID);
            return View(weight);
        }

        // GET: WeightTracking/Weights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weight weight = db.Weights.Find(id);
            if (weight == null)
            {
                return HttpNotFound();
            }
            return View(weight);
        }

        // POST: WeightTracking/Weights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weight weight = db.Weights.Find(id);
            db.Weights.Remove(weight);
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
