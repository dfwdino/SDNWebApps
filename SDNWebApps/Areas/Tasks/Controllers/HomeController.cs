using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Tasks.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Tasks/Home/

        SDNAppsEntities sdnApps = new SDNAppsEntities();

        //Need to fix the user id isse
        public ActionResult Index(int userid=2112, bool showAll = false)
        {
            IQueryable<Task> gtasks = sdnApps.Tasks;
            Item item = new Item();

            if (!userid.Equals(2112))
            {
                gtasks = gtasks.Where(m => m.PersonID.Equals(userid));
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

            return View(gtasks.ToList());
        }

    }
}
