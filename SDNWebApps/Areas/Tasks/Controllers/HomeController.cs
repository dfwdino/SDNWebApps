﻿using System;
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
        public ActionResult Index(int? userid=null, bool showAll = false)
        {
            IQueryable<Task> gtasks = sdnApps.Tasks;
            Item item = new Item();

            if (userid!=null)
            {
                gtasks = gtasks.Where(m => m.PersonID.Equals(userid)).OrderBy(m => m.DueDate);
            }


            if (showAll)
            {
                ViewBag.Title = "All Tasks";
                
            }
            else
            {
                gtasks = gtasks.Where(m => m.Done == showAll).OrderBy(m => m.DueDate);
                ViewBag.Title = "Tasks To-Do";
            }

            return View(gtasks.ToList());
        }

    }
}
