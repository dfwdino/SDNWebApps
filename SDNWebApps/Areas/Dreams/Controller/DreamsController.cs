using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Dreams.Controller
{
    public class DreamsController : System.Web.Mvc.Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();

        // GET: Dreams
        public ActionResult Index()
        {
            var dreams = db.Dreams.Include(d => d.Person1).Where(d => d.Deleted==false).OrderByDescending(m => m.Date);

            return View(dreams.ToList());
        }

        // GET: Dreams/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dream dream = db.Dreams.Find(id);
            if (dream == null)
            {
                return HttpNotFound();
            }
            return View(dream);
        }

        // GET: Dreams/Create
        public ActionResult Create()
        {
            ViewBag.Person = new SelectList(db.People, "ID", "PersonName");
            return View();
        }

        // POST: Dreams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Dream1,Person,DidMeditation,Links,Longitude,Latitude")] Dream dream)
        {
            //if (ModelState.IsValid)
            //{
                dream.ID = Guid.NewGuid();

            if (dream.Date.Equals(new DateTime()) && ModelState["Date"].Value != null)
            {
                var etempDT =
                    ModelState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                        .ToArray()
                        .First(m => m.Key == "Date")
                        .Value.Value.AttemptedValue;
                if (!etempDT.Length.Equals(0))
                {
                    dream.Date= Convert.ToDateTime(FixFuckenDate(etempDT));
                }
            }

            //dream.Dream1 = dream.Dream1;

            db.Dreams.Add(dream);
            db.SaveChanges();
            return RedirectToAction("Index");

           // }

            ViewBag.Person = new SelectList(db.People, "ID", "PersonName", dream.Person);
            return View(dream);
        }

        // GET: Dreams/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dream dream = db.Dreams.Find(id);
            if (dream == null)
            {
                return HttpNotFound();
            }
            ViewBag.Person = new SelectList(db.People, "ID", "PersonName", dream.Person);
            return View(dream);
        }

        // POST: Dreams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Dream1,Person")] Dream dream)
        {
            //if (ModelState.IsValid)
            //{
                db.Entry(dream).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            ViewBag.Person = new SelectList(db.People, "ID", "PersonName", dream.Person);
            return View(dream);
        }

        // GET: Dreams/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dream dream = db.Dreams.Find(id);
            if (dream == null)
            {
                return HttpNotFound();
            }
            return View(dream);
        }

        // POST: Dreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Dream dream = db.Dreams.Find(id);
            dream.Deleted = true;
            //db.Dreams.Remove(dream);
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

        private DateTime? FixFuckenDate(string datetime)
        {
           if (datetime.Length.Equals(0))
                return null;

            var newstr = new string(datetime.Where(c => c < 128).ToArray());

            return DateTime.Parse(newstr, new CultureInfo("en-US"), DateTimeStyles.None);
        }
    }
}
