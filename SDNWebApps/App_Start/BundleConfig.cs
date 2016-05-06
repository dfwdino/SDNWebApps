﻿using System.Web;
using System.Web.Optimization;

namespace SDNWebApps
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
//            #if DEBUG

//        BundleTable.EnableOptimizations = false;
//#else
//        BundleTable.EnableOptimizations = true;
//#endif

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                            "~/Content/bootstrap.css",
                            "~/Content/bootstrap-theme.css",
                            "~/Content/site.css",
                            "~/Content/bootstrap-responsive.css"));
            
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
            
            bundles.Add(new StyleBundle("~/Scripts/jquery-ui-1114custom/").Include(
                "~/Scripts/jquery-ui-1114custom/jquery-ui.min.css",
                "~/Scripts/jquery-ui-1114custom/jquery-ui.structure.min.css",
                "~/Scripts/jquery-ui-1114custom/jquery-ui.theme.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/GPS").Include("~/Scripts/GPS.js"));



            #region SDNWebApps

            bundles.Add(new ScriptBundle("~/bundles/grocery").Include(
                           "~/Scripts/items.js",
                           "~/Scripts/store.js"));

            bundles.Add(new ScriptBundle("~/bundles/task").Include(
                        "~/Scripts/tasks.js"));

            //bundles.Add(new StyleBundle("~/Content/grocery").Include("~/Content/grocery.css"));

            //bundles.Add(new StyleBundle("~/Content/main").Include("~/Content/main.css"));


            #endregion




        }
    }
}