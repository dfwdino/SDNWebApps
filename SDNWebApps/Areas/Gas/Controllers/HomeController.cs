﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDNWebApps.Areas.Gas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Gas/Home
        public ActionResult Index()
        {
            return RedirectToAction("List", "Person");
        }
    }
}