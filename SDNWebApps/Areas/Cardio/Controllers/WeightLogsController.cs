using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SDNWebApps.Infrastructure;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Cardio.Controllers
{
    [Access]
    public class WeightLogsController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Cardio/WeightLogs
        public ActionResult Index()
        {
            int userid = Convert.ToInt32(Request.Cookies["SDNWebApps"]["SDNID"]);

            return View(db.WeightLogs.Where(m => m.Deleted == false && m.PersonID == userid).ToList());
        }

        // GET: Cardio/WeightLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightLog weightLog = db.WeightLogs.Find(id);
            if (weightLog == null)
            {
                return HttpNotFound();
            }
            return View(weightLog);
        }

        // GET: Cardio/WeightLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cardio/WeightLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PersonID,Weight,WeightDate,Deleted")] WeightLog weightLog)
        {
            if (ModelState.IsValid)
            {   weightLog.PersonID = Convert.ToInt32(Request.Cookies["SDNWebApps"]["SDNID"]);
                db.WeightLogs.Add(weightLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weightLog);
        }

        // GET: Cardio/WeightLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightLog weightLog = db.WeightLogs.Find(id);
            if (weightLog == null)
            {
                return HttpNotFound();
            }
            return View(weightLog);
        }

        // POST: Cardio/WeightLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PersonID,Weight,WeightDate,Deleted")] WeightLog weightLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weightLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weightLog);
        }

        // GET: Cardio/WeightLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightLog weightLog = db.WeightLogs.Find(id);
            if (weightLog == null)
            {
                return HttpNotFound();
            }
            return View(weightLog);
        }

        // POST: Cardio/WeightLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeightLog weightLog = db.WeightLogs.Find(id);
            db.WeightLogs.Remove(weightLog);
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


        public ActionResult CreateBarChart()
        {
            int userid = Convert.ToInt32(Request.Cookies["SDNWebApps"]["SDNID"]);

            List<string> dt = db.WeightLogs.Where(m => m.PersonID == userid).ToList().Select(m => m.WeightDate.ToShortDateString()).ToList();


            var myChart = new Chart(width: 600, height: 400)
           .AddTitle("Weight")
           .AddSeries(
               name: "weight",
               xValue: dt.ToArray(),
               yValues: db.WeightLogs.Where(m => m.PersonID == userid).Select(m => m.Weight.ToString()).ToArray()).GetBytes("jpeg");

            

            return File(myChart, "image/bytes");
        }

    }
}
