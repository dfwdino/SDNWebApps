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
    public class LiquidSizesController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Baby/LiquidSizes
        public ActionResult Index()
        {
            var liquidSizes = db.LiquidSizes.Where(m => m.Deleted == false).OrderBy(m => m.Type);
            return View(liquidSizes.ToList());
        }

        // GET: Baby/LiquidSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquidSize liquidSize = db.LiquidSizes.Find(id);
            if (liquidSize == null)
            {
                return HttpNotFound();
            }
            return View(liquidSize);
        }

        // GET: Baby/LiquidSizes/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.LiquidSizes, "Id", "Type");
            return View();
        }

        // POST: Baby/LiquidSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Deleted")] LiquidSize liquidSize)
        {
            if (ModelState.IsValid)
            {
                db.LiquidSizes.Add(liquidSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.LiquidSizes, "Id", "Type", liquidSize.Id);
            return View(liquidSize);
        }

        // GET: Baby/LiquidSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquidSize liquidSize = db.LiquidSizes.Find(id);
            if (liquidSize == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.LiquidSizes, "Id", "Type", liquidSize.Id);
            return View(liquidSize);
        }

        // POST: Baby/LiquidSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Deleted")] LiquidSize liquidSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liquidSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.LiquidSizes, "Id", "Type", liquidSize.Id);
            return View(liquidSize);
        }

        // GET: Baby/LiquidSizes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LiquidSize liquidSize = db.LiquidSizes.Find(id);
        //    if (liquidSize == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(liquidSize);
        //}

        // POST: Baby/LiquidSizes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LiquidSize liquidSize = db.LiquidSizes.Find(id);
            //db.LiquidSizes.Remove(liquidSize);
            liquidSize.Deleted = true;
           
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
