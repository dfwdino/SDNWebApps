using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Gas.Controllers
{
    public class GasolineTypesController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Gas/GasolineTypes
        public ActionResult Index()
        {
            return View(db.GasolineTypes.ToList());
        }

        // GET: Gas/GasolineTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasolineType gasolineType = db.GasolineTypes.Find(id);
            if (gasolineType == null)
            {
                return HttpNotFound();
            }
            return View(gasolineType);
        }

        // GET: Gas/GasolineTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gas/GasolineTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TypeName")] GasolineType gasolineType)
        {
            if (ModelState.IsValid)
            {
                db.GasolineTypes.Add(gasolineType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gasolineType);
        }

        // GET: Gas/GasolineTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasolineType gasolineType = db.GasolineTypes.Find(id);
            if (gasolineType == null)
            {
                return HttpNotFound();
            }
            return View(gasolineType);
        }

        // POST: Gas/GasolineTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TypeName")] GasolineType gasolineType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasolineType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gasolineType);
        }

        // GET: Gas/GasolineTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasolineType gasolineType = db.GasolineTypes.Find(id);
            if (gasolineType == null)
            {
                return HttpNotFound();
            }
            return View(gasolineType);
        }

        // POST: Gas/GasolineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GasolineType gasolineType = db.GasolineTypes.Find(id);
            db.GasolineTypes.Remove(gasolineType);
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
