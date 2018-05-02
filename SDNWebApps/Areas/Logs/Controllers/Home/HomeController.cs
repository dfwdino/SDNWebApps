using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Logs
{
    public class HomeController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Logs/Home
        public ActionResult Index()
        {
            return View(db.Loggings.Where(m => m.IPAddress != "::1").OrderByDescending(m => m.Date).Take(100).ToList());
        }

        // GET: Logs/Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logging logging = db.Loggings.Find(id);
            if (logging == null)
            {
                return HttpNotFound();
            }
            return View(logging);
        }

        // GET: Logs/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logs/Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Logging logging)
        {
            if (ModelState.IsValid)
            {
                db.Loggings.Add(logging);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logging);
        }

        // GET: Logs/Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logging logging = db.Loggings.Find(id);
            if (logging == null)
            {
                return HttpNotFound();
            }
            return View(logging);
        }

        // POST: Logs/Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,IPAddress,ControllerName,ActionName,ActionParameters,AbsoluteUri,Notes")] Logging logging)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logging).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logging);
        }

        // GET: Logs/Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logging logging = db.Loggings.Find(id);
            if (logging == null)
            {
                return HttpNotFound();
            }
            return View(logging);
        }

        // POST: Logs/Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logging logging = db.Loggings.Find(id);
            db.Loggings.Remove(logging);
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
