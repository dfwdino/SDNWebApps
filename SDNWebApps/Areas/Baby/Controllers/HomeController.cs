﻿using SDNWebApps.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDNWebApps.Areas.Baby.Controllers
{
    [Access]
    public class HomeController : Controller
    {
        // GET: Baby/Home
        public ActionResult Index()
        {

            return RedirectToAction("Index","DoneThings");
        }
    }
}