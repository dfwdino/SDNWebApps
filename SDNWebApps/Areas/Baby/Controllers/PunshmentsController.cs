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
    public class PunshmentsController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Baby/Punshments
        public ActionResult Index()
        {
            var punshments = db.Punshments.Include(p => p.BabyName).Include(p => p.PunshmentAction);
            return View(punshments.ToList());
        }

        // GET: Baby/Punshments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punshment punshment = db.Punshments.Find(id);
            if (punshment == null)
            {
                return HttpNotFound();
            }
            return View(punshment);
        }

        // GET: Baby/Punshments/Create
        public ActionResult Create()
        {
            ViewBag.BabyNameID = new SelectList(db.BabyNames, "ID", "BabyName1");
            ViewBag.PunshmentActions = new SelectList(db.PunshmentActions, "index", "Title");
            return View();
        }

        // POST: Baby/Punshments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "index,BabyNameID,PunshmentActions,StartTime,Delete,Notes,IPAddress,Longitude,Latitude,LiquidSizeID")] Punshment punshment)
        {
            if (ModelState.IsValid)
            {
                db.Punshments.Add(punshment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BabyNameID = new SelectList(db.BabyNames, "ID", "BabyName1", punshment.BabyNameID);
            ViewBag.PunshmentActions = new SelectList(db.PunshmentActions, "index", "Title", punshment.PunshmentActions);
            return View(punshment);
        }

        // GET: Baby/Punshments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punshment punshment = db.Punshments.Find(id);
            if (punshment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BabyNameID = new SelectList(db.BabyNames, "ID", "BabyName1", punshment.BabyNameID);
            ViewBag.PunshmentActions = new SelectList(db.PunshmentActions, "index", "Title", punshment.PunshmentActions);
            return View(punshment);
        }

        // POST: Baby/Punshments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "index,BabyNameID,PunshmentActions,StartTime,Delete,Notes,IPAddress,Longitude,Latitude,LiquidSizeID")] Punshment punshment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punshment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BabyNameID = new SelectList(db.BabyNames, "ID", "BabyName1", punshment.BabyNameID);
            ViewBag.PunshmentActions = new SelectList(db.PunshmentActions, "index", "Title", punshment.PunshmentActions);
            return View(punshment);
        }

        // GET: Baby/Punshments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punshment punshment = db.Punshments.Find(id);
            if (punshment == null)
            {
                return HttpNotFound();
            }
            return View(punshment);
        }

        // POST: Baby/Punshments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Punshment punshment = db.Punshments.Find(id);
            db.Punshments.Remove(punshment);
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
