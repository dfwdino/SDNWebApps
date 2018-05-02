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
    public class RemindersController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Baby/Reminders
        public ActionResult Index()
        {
            var reminders = db.Reminders.Where(m => m.Deleted == false).Include(r => r.Action).Include(r => r.ReminderType);
            return View(reminders.ToList());
        }

        // GET: Baby/Reminders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reminder reminder = db.Reminders.Find(id);
            if (reminder == null)
            {
                return HttpNotFound();
            }
            return View(reminder);
        }

        // GET: Baby/Reminders/Create
        public ActionResult Create()
        {
            ViewBag.ActionID = new SelectList(db.Actions1.Where(m => m.Delete==false).OrderBy(m=>m.Title), "index", "Title");
            ViewBag.RemeberType = new SelectList(db.ReminderTypes.Where(m => m.Deleted == false), "ID", "Type");
            return View();
        }

        // POST: Baby/Reminders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Deleted,IPAddress,Longitude,Latitude,StartDate,EndDate,ActionID,RemeberType,Every")] Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                db.Reminders.Add(reminder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActionID = new SelectList(db.Actions1.Where(m => m.Delete == false).OrderBy(m => m.Title), "index", "Title", reminder.ActionID);
            ViewBag.RemeberType = new SelectList(db.ReminderTypes.Where(m => m.Deleted == false), "ID", "Type", reminder.RemeberType);
            return View(reminder);
        }

        // GET: Baby/Reminders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reminder reminder = db.Reminders.Find(id);
            if (reminder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActionID = new SelectList(db.Actions1.Where(m => m.Delete == false).OrderBy(m => m.Title), "index", "Title", reminder.ActionID);
            ViewBag.RemeberType = new SelectList(db.ReminderTypes, "ID", "Type", reminder.RemeberType);
            return View(reminder);
        }

        // POST: Baby/Reminders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Deleted,IPAddress,Longitude,Latitude,StartDate,EndDate,ActionID,RemeberType,Every")] Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reminder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActionID = new SelectList(db.Actions1.Where(m => m.Delete==false).OrderBy(m => m.Title), "index", "Title", reminder.ActionID);
            ViewBag.RemeberType = new SelectList(db.ReminderTypes, "ID", "Type", reminder.RemeberType);
            return View(reminder);
        }

        // GET: Baby/Reminders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reminder reminder = db.Reminders.Find(id);
            if (reminder == null)
            {
                return HttpNotFound();
            }
            return View(reminder);
        }

        // POST: Baby/Reminders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reminder reminder = db.Reminders.Find(id);
            //db.Reminders.Remove(reminder);
            reminder.Deleted = true;
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
