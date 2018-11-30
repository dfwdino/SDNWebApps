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
            DateTime dt = DateTime.Now.AddDays(-30);


            return View(db.WeightLogs.Where(m => m.Deleted == false && m.PersonID == userid && m.WeightDate >= dt)
                            .OrderByDescending(m => m.WeightDate).ToList());
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
        public ActionResult Create([Bind(Include = "ID,PersonID,Weight,WeightDate,Deleted,Notes")] WeightLog weightLog)
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
        public ActionResult Edit([Bind(Include = "ID,PersonID,Weight,WeightDate,Deleted,Notes")] WeightLog weightLog)
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
            List<string> dt = new List<string>();
            List<string> weightLogs = new List<string>();

            dt.Add(db.WeightLogs.Where(m => m.PersonID == userid).OrderBy(m => m.WeightDate)
                            .Take(1).Select(m => m.WeightDate).First().ToShortDateString().ToString());

            dt.AddRange(db.WeightLogs.Where(m => m.PersonID == userid).OrderByDescending(m => m.WeightDate)
                                    .Take(5).ToList().Select(m => m.WeightDate.ToShortDateString()));


            weightLogs.Add(db.WeightLogs.Where(m => m.PersonID == userid)
                                        .OrderBy(m => m.WeightDate)
                                        .Take(1)
                                        .Select(m => m.Weight.ToString())
                                        .First());

            weightLogs.AddRange(db.WeightLogs
                                    .Where(m => m.PersonID == userid)
                                    .OrderByDescending(m => m.WeightDate)
                                    .Take(5)
                                    .Select(m => m.Weight.ToString()));

            var myChart = new Chart(width: 300, height: 300)
           .AddTitle("Weight")
           .AddSeries(
               name: "weight",
               xValue: dt.ToArray(),
               yValues: weightLogs.ToArray()).GetBytes("jpeg");

            

            return File(myChart, "image/bytes");
        }

    }
}
