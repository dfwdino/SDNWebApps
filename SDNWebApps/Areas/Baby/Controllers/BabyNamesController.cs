using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Baby.Controllers
{
    public class BabyNamesController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Baby/BabyNames
        public ActionResult Index()
        {
            return View(db.BabyNames.ToList());
        }

        // GET: Baby/BabyNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BabyName babyName = db.BabyNames.Find(id);
            if (babyName == null)
            {
                return HttpNotFound();
            }
            return View(babyName);
        }

        // GET: Baby/BabyNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Baby/BabyNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BabyName1,Delete,IPAddress,Longitude,Latitude")] BabyName babyName)
        {
            if (ModelState.IsValid)
            {
                db.BabyNames.Add(babyName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(babyName);
        }

        // GET: Baby/BabyNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BabyName babyName = db.BabyNames.Find(id);
            if (babyName == null)
            {
                return HttpNotFound();
            }
            return View(babyName);
        }

        // POST: Baby/BabyNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BabyName1,Delete,IPAddress,Longitude,Latitude")] BabyName babyName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(babyName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(babyName);
        }

        // GET: Baby/BabyNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BabyName babyName = db.BabyNames.Find(id);
            if (babyName == null)
            {
                return HttpNotFound();
            }
            return View(babyName);
        }

        // POST: Baby/BabyNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BabyName babyName = db.BabyNames.Find(id);
            babyName.Delete = true;
            //db.BabyNames.Remove(babyName);
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
