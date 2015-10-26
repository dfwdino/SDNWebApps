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
    public class StationsController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Gas/Stations
        public ActionResult Index()
        {
            var stations = db.Stations;
            return View(stations.ToList());
        }

        // GET: Gas/Stations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // GET: Gas/Stations/Create
        public ActionResult Create()
        {
            //ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName");
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName");
            return View();
        }

        // POST: Gas/Stations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StationID,StationName,CreatedOn,UpdatedOn,IPAddress,Broswer,Deleted")] Station station)
        {
            if (ModelState.IsValid)
            {
                station.CreatedOn = DateTime.Now;
                db.Stations.Add(station);
                db.SaveChanges();
                return RedirectToAction("List","Person");
            }

            //ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", station.StationID);
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", station.StationID);
            return View(station);
        }

        // GET: Gas/Stations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            //ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", station.StationID);
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", station.StationID);
            return View(station);
        }

        // POST: Gas/Stations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StationID,StationName,CreatedOn,UpdatedOn,IPAddress,Broswer,Deleted")] Station station)
        {
            if (ModelState.IsValid)
            {
                db.Entry(station).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", station.StationID);
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", station.StationID);
            return View(station);
        }

        // GET: Gas/Stations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // POST: Gas/Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Station station = db.Stations.Find(id);
            db.Stations.Remove(station);
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
