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
    public class PunshmentActionsController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Baby/PunshmentActions
        public ActionResult Index()
        {
            return View(db.PunshmentActions.ToList());
        }

        // GET: Baby/PunshmentActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PunshmentAction punshmentAction = db.PunshmentActions.Find(id);
            if (punshmentAction == null)
            {
                return HttpNotFound();
            }
            return View(punshmentAction);
        }

        // GET: Baby/PunshmentActions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Baby/PunshmentActions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "index,Title,Delete,IPAddress,Longitude,Latitude")] PunshmentAction punshmentAction)
        {
            if (ModelState.IsValid)
            {
                db.PunshmentActions.Add(punshmentAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(punshmentAction);
        }

        // GET: Baby/PunshmentActions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PunshmentAction punshmentAction = db.PunshmentActions.Find(id);
            if (punshmentAction == null)
            {
                return HttpNotFound();
            }
            return View(punshmentAction);
        }

        // POST: Baby/PunshmentActions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "index,Title,Delete,IPAddress,Longitude,Latitude")] PunshmentAction punshmentAction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punshmentAction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(punshmentAction);
        }

        // GET: Baby/PunshmentActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PunshmentAction punshmentAction = db.PunshmentActions.Find(id);
            if (punshmentAction == null)
            {
                return HttpNotFound();
            }
            return View(punshmentAction);
        }

        // POST: Baby/PunshmentActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PunshmentAction punshmentAction = db.PunshmentActions.Find(id);
            //db.PunshmentActions.Remove(punshmentAction);
            punshmentAction.Delete = true;
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
