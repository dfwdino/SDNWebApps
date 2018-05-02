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

namespace SDNWebApps.Areas.Baby.Controllers
{
    [Access]
    public class ReminderTypesController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Baby/ReminderTypes
        public ActionResult Index()
        {
            return View(db.ReminderTypes.ToList());
        }

        // GET: Baby/ReminderTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReminderType reminderType = db.ReminderTypes.Find(id);
            if (reminderType == null)
            {
                return HttpNotFound();
            }
            return View(reminderType);
        }

        // GET: Baby/ReminderTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Baby/ReminderTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,Deleted,IPAddress,Longitude,Latitude")] ReminderType reminderType)
        {
            if (ModelState.IsValid)
            {
                db.ReminderTypes.Add(reminderType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reminderType);
        }

        // GET: Baby/ReminderTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReminderType reminderType = db.ReminderTypes.Find(id);
            if (reminderType == null)
            {
                return HttpNotFound();
            }
            return View(reminderType);
        }

        // POST: Baby/ReminderTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type,Deleted,IPAddress,Longitude,Latitude")] ReminderType reminderType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reminderType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reminderType);
        }

        // GET: Baby/ReminderTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReminderType reminderType = db.ReminderTypes.Find(id);
            if (reminderType == null)
            {
                return HttpNotFound();
            }
            return View(reminderType);
        }

        // POST: Baby/ReminderTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReminderType reminderType = db.ReminderTypes.Find(id);
            db.ReminderTypes.Remove(reminderType);
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
