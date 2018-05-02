using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Infrastructure;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Tasks.Controllers
{
    [Access]
    public class HomeController : Controller
    {
        //
        // GET: /Tasks/Home/

        SDNAppsEntities sdnApps = new SDNAppsEntities();

        //Need to fix the user id isse
        public ActionResult Index(int? userid=null, bool showAll = false)
        {
            IQueryable<Task> gtasks = sdnApps.Tasks;
            Item item = new Item();

            if (userid!=null)
            {
                gtasks = gtasks.Where(m => m.PersonID == userid);
            }


            if (showAll)
            {
                ViewBag.Title = "All Tasks";
                
            }
            else
            {
                gtasks = gtasks.Where(m => m.Done == showAll);
                ViewBag.Title = "Tasks To-Do";
            }

            return View(gtasks.OrderBy(m => m.DueDate).ToList());
        }

    }
}
