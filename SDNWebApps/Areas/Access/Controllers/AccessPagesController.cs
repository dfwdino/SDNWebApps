using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Access.Controllers
{
    public class AccessPagesController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Access/AccessPages
        public ActionResult Index()
        {
            var accessPages = db.AccessPages.Include(a => a.Person);
            return View(accessPages.ToList());
        }

        // GET: Access/AccessPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessPage accessPage = db.AccessPages.Find(id);
            if (accessPage == null)
            {
                return HttpNotFound();
            }
            return View(accessPage);
        }

        // GET: Access/AccessPages/Create
        public ActionResult Create()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            ViewBag.PersonID = new SelectList(db.People, "ID", "PersonName");
            var Contorllers = asm.GetTypes()
                .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                .Select(x => new { ControllerName = x.DeclaringType.Name.Replace("Controller","")}).Distinct()
                .OrderBy(x => x.ControllerName).ToList();

            ViewBag.AccessPage1 = new SelectList(Contorllers, "ControllerName", "ControllerName");

            return View();
        }

        // POST: Access/AccessPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccessPage accessPage)
        {
            return View(accessPage);

            if (ModelState.IsValid)
            {
                db.AccessPages.Add(accessPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.People, "ID", "PersonName", accessPage.PersonID);
            return View(accessPage);
        }

        // GET: Access/AccessPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessPage accessPage = db.AccessPages.Find(id);
            if (accessPage == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.People, "ID", "PersonName", accessPage.PersonID);
            return View(accessPage);
        }

        // POST: Access/AccessPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AccessPage1,Disactive,PersonID")] AccessPage accessPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.People, "ID", "PersonName", accessPage.PersonID);
            return View(accessPage);
        }

        // GET: Access/AccessPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessPage accessPage = db.AccessPages.Find(id);
            if (accessPage == null)
            {
                return HttpNotFound();
            }
            return View(accessPage);
        }

        // POST: Access/AccessPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessPage accessPage = db.AccessPages.Find(id);
            db.AccessPages.Remove(accessPage);
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
