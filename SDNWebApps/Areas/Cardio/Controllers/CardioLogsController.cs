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

namespace SDNWebApps.Areas.Cardio.Controllers
{
    [Access]
    public class CardioLogsController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Cardio/CardioLogs
        public ActionResult Index()
        {
            int userid = Convert.ToInt32(Request.Cookies["SDNWebApps"]["SDNID"]);

            var CardioLogs = db.CardioLogs.Include(c => c.CardioItem).Include(c => c.Person)
                                    .Where(m => m.Deleted == false && m.CreatedBy == userid)
                                    .Take(50)
                                    .OrderByDescending(m => m.WorkoutDate);

            return View(CardioLogs.ToList());
        }

        // GET: Cardio/CardioLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardioLog CardioLog = db.CardioLogs.Find(id);
            if (CardioLog == null)
            {
                return HttpNotFound();
            }
            return View(CardioLog);
        }

        // GET: Cardio/CardioLogs/Create
        public ActionResult Create()
        {
            ViewBag.CardioItemID = new SelectList(db.CardioItems, "ID", "Item");
            ViewBag.CreatedBy = new SelectList(db.People, "ID", "PersonName");

            return View();
        }

        // POST: Cardio/CardioLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CardioItemID,Time,CaloriesBurned,WorkoutDate,CreatedTime,Deleted,CreatedBy")] CardioLog CardioLog)
        {
            if (ModelState.IsValid)
            {   
                CardioLog.CreatedBy = Convert.ToInt32(Request.Cookies["SDNWebApps"]["SDNID"]);
                CardioLog.CreatedTime = DateTime.Now;
                
                db.CardioLogs.Add(CardioLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardioItemID = new SelectList(db.CardioItems, "ID", "Item", CardioLog.CardioItemID);
            ViewBag.CreatedBy = new SelectList(db.People, "ID", "PersonName", CardioLog.CreatedBy);
            return View(CardioLog);
        }

        // GET: Cardio/CardioLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardioLog CardioLog = db.CardioLogs.Find(id);
            if (CardioLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardioItemID = new SelectList(db.CardioItems, "ID", "Item", CardioLog.CardioItemID);
            ViewBag.CreatedBy = new SelectList(db.People, "ID", "PersonName", CardioLog.CreatedBy);
            return View(CardioLog);
        }

        // POST: Cardio/CardioLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CardioItemID,Time,CaloriesBurned,WorkoutDate,CreatedTime,Deleted,CreatedBy")] CardioLog CardioLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(CardioLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardioItemID = new SelectList(db.CardioItems, "ID", "Item", CardioLog.CardioItemID);
            ViewBag.CreatedBy = new SelectList(db.People, "ID", "PersonName", CardioLog.CreatedBy);
            return View(CardioLog);
        }

        // GET: Cardio/CardioLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardioLog CardioLog = db.CardioLogs.Find(id);
            if (CardioLog == null)
            {
                return HttpNotFound();
            }
            return View(CardioLog);
        }

        // POST: Cardio/CardioLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardioLog CardioLog = db.CardioLogs.Find(id);
            CardioLog.Deleted = true;
            //db.CardioLogs.Remove(CardioLog);
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
