using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Baby.Controllers
{
    public class ActionsController : Controller
    {
        // GET: Baby/Actions
        SDNAppsEntities _se = new SDNAppsEntities();

        public ActionResult Index()
        {


            return View(_se.Actions1.Where(m => m.Delete == false));
        }


        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(SDNWebApps.Views.Actions actions)
        {
            _se.Actions1.Add(actions);
            _se.SaveChanges();

            var act = new Actions();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var actionItem = _se.Actions1.First(m => m.index == id);
            return View(actionItem);
        }
        [HttpPost]
        public ActionResult Edit(Actions actionitem)
        {
            var actionItem = _se.Actions1.First(m => m.index == actionitem.index);

            actionItem.Title = actionitem.Title;
            _se.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var actionItem = _se.Actions1.First(m => m.index == id);

            actionItem.Delete = true;
            _se.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}