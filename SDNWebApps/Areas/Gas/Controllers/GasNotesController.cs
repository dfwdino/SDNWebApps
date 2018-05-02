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

namespace SDNWebApps.Areas.Gas.Controllers
{
    [Access]
    public class GasNotesController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Gas/GasNotes
        public ActionResult Index(int? id)
        {
            var gasNotes = db.GasNotes.Include(g => g.Auto);
            if (id != null)
                gasNotes = gasNotes.Where(m => m.AutoID == id);

            return View(gasNotes.ToList());
        }

        // GET: Gas/GasNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasNote gasNote = db.GasNotes.Find(id);
            if (gasNote == null)
            {
                return HttpNotFound();
            }
            return View(gasNote);
        }

        // GET: Gas/GasNotes/Create
        public ActionResult Create(int id)
        {
            //ViewBag.NotesID = new SelectList(db.Autos, "ID", "AutoName");
            ViewBag.AutoID = new SelectList(db.Autos, "ID", "AutoName");

            GasNote gn = new GasNote();
            if(id != null)
            gn.AutoID = id;
            return View(gn);
        }

        // POST: Gas/GasNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Note,AutoID,CreatedOn,UpdatedOn,IPAddress,Broswer,Deleted,NoteDate")] GasNote gasNote)
        {
            if (ModelState.IsValid)
            {
                gasNote.CreatedOn = DateTime.Now;
                //gasNote.NotesID = db.GasNotes.Count() + 1; //I should not have to do this... by why do i have too.... again!!!!!!!
                db.GasNotes.Add(gasNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.NotesID = new SelectList(db.Autos, "ID", "AutoName", gasNote.NotesID);
            ViewBag.AutoID = new SelectList(db.Autos, "ID", "AutoName", gasNote.AutoID);
            return View(gasNote);
        }

        // GET: Gas/GasNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasNote gasNote = db.GasNotes.Find(id);
            if (gasNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.NotesID = new SelectList(db.Autos, "ID", "AutoName", gasNote.NotesID);
            ViewBag.AutoID = new SelectList(db.Autos, "ID", "AutoName", gasNote.AutoID);
            return View(gasNote);
        }

        // POST: Gas/GasNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotesID,Note,AutoID,CreatedOn,UpdatedOn,IPAddress,Broswer,Deleted,NoteDate")] GasNote gasNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NotesID = new SelectList(db.Autos, "ID", "AutoName", gasNote.NotesID);
            ViewBag.AutoID = new SelectList(db.Autos, "ID", "AutoName", gasNote.AutoID);
            return View(gasNote);
        }

        // GET: Gas/GasNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasNote gasNote = db.GasNotes.Find(id);
            if (gasNote == null)
            {
                return HttpNotFound();
            }
            return View(gasNote);
        }

        // POST: Gas/GasNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GasNote gasNote = db.GasNotes.Find(id);
            //db.GasNotes.Remove(gasNote);
            gasNote.Deleted = true;
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
