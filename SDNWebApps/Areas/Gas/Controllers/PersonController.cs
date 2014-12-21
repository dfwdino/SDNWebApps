using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Areas.Gas.Models.Person;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Gas.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Gas/Person/

        public ActionResult List()
        {
            SDNAppsEntities se = new SDNAppsEntities();

            ListViewModel person =new ListViewModel(se.People.ToList());

            return View(person);
        }
         
        public ActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Add(AddViewModel avm)
        {
            SDNAppsEntities seEntities = new SDNAppsEntities();

            Person person = new Person();

            person.PersonName = avm.Personname;

            seEntities.People.Add(person);
            seEntities.SaveChanges();

            ViewBag.Title = "Edit";

            return View(avm);
        }

    }
}
