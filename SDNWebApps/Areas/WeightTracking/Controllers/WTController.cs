using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.WeightTracking
{
    public class WtController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: /WeightTracking/Default1/
        public ActionResult Index()
        {
            var sizes = db.Sizes.Include(s => s.Person);
            return View(sizes.ToList());
        }

        // GET: /WeightTracking/Default1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // GET: /WeightTracking/Default1/Create
        public ActionResult Create()
        {
            ViewBag.PeopleID = new SelectList(db.People, "ID", "PersonName");
            return View();
        }

        // POST: /WeightTracking/Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "SizeID,PeopleID,Wrist,Chest,Forearm,Waist,Thigh,Hip,Calve,Bicep,Neck,Notes,StatusDate")] Size size)
        {
            if (ModelState.IsValid)
            {
                size.CreatedOn = DateTime.Now;
                db.Sizes.Add(size);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PeopleID = new SelectList(db.People, "ID", "PersonName", size.PeopleID);
            return View(size);
        }

        // GET: /WeightTracking/Default1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            ViewBag.PeopleID = new SelectList(db.People, "ID", "PersonName", size.PeopleID);
            return View(size);
        }

        // POST: /WeightTracking/Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include= "SizeID,PeopleID,Wrist,Chest,Forearm,Waist,Thigh,Hip,Calve,Bicep,Neck,Notes,CreatedOn,UpdatedOn,IPAddress,Broswer,StatusDate")] Size size)
        {
            if (ModelState.IsValid)
            {
                db.Entry(size).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PeopleID = new SelectList(db.People, "ID", "PersonName", size.PeopleID);
            return View(size);
        }

        // GET: /WeightTracking/Default1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // POST: /WeightTracking/Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Size size = db.Sizes.Find(id);
            db.Sizes.Remove(size);
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
