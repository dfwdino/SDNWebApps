using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SDNWebApps.Areas.Gas.Models.Miles;
using SDNWebApps.Infrastructure;
using SDNWebApps.Views;
using SDNWebApps.Infrastructure;

namespace SDNWebApps.Areas.Gas.Controllers
{
    [Access]
    public class MilesController : Controller
    {
        SDNAppsEntities ae = new SDNAppsEntities();

        public ActionResult JSONList(int id, bool viewall = false)
        {   
            List<Gallon> gallons = ae.Gallons.Where(m => m.AutoID == id && m.Delete == null).OrderByDescending(m => m.TotalMiles).Take(20).ToList();
            List<JSONGallonsView> jgv = new List<JSONGallonsView>();

            decimal lastmiles = 0;

            foreach (var item in gallons.OrderBy(m => m.TotalMiles))
            {
                JSONGallonsView gv = new JSONGallonsView();

                gv.GasDate = item.GasDate;
                gv.TotalGallons = item.TotalGallons;
                gv.TotalMiles = item.TotalMiles;
                gv.TotalPrice = item.TotalPrice;
                gv.Store = item.Station.StationName;
                gv.DrivenMiles = lastmiles.Equals(0) ? 0 : (int)(item.TotalMiles - lastmiles);
                gv.MPG = lastmiles.Equals(0) ? 0 : ((item.TotalMiles - lastmiles) / (decimal)gv.TotalGallons);
                gv.EngineRunTime = item.EngineRunTime;
                gv.ID = item.ID;
                lastmiles = gv.TotalMiles;
                jgv.Add(gv);
            }


            return View(jgv);
        }

            public ActionResult List(int id, bool viewall = false)
        {
            ListViewModel lmvModel;

            if (viewall)
            {
                lmvModel = new ListViewModel(ae.Gallons.Where(m => m.AutoID == id).OrderByDescending(m => m.TotalMiles).ToList());
            }
            else
            {
                lmvModel = new ListViewModel(ae.Gallons.Where(m => m.AutoID == id).OrderByDescending(m => m.TotalMiles)
                   .Take(5).OrderBy(m => m.TotalMiles).ToList());
            }

            
            lmvModel.PersonID = ae.Autos.First(m => m.ID == id).Person.ID.ToString();
            lmvModel.autoID = id;
            lmvModel.AutoName = ae.Autos.First(m => m.ID == id).AutoName;

            return View(lmvModel);
        }

       

        public ActionResult Add(int id)
        {
            Models.Miles.AddViewModel lmvModel = new Models.Miles.AddViewModel(id);
            ViewBag.Title = "Add";

            lmvModel.TotalGallons = null;
            lmvModel.TotalMiles = null;
            lmvModel.DrivenMiles = null;
            lmvModel.EngineRunTime = string.Empty;
            
            return View(lmvModel);
        }

        [HttpPost]
        public ActionResult Add(AddViewModel addviewmodel)
        {

            Gallon gallon = new Gallon
            {
                AutoID = addviewmodel.AutoID,
                TotalMiles = (int)(addviewmodel.TotalMiles ?? 0),
                TotalGallons = addviewmodel.TotalGallons ?? 0,
                DrivenMiles = addviewmodel.DrivenMiles ?? 0,
                TotalPrice = addviewmodel.TotalPrice,
                TankFilled = addviewmodel.TankFilled,
                StationID = addviewmodel.SelectedStation,
                Latitude = addviewmodel.Latitude,
                Longitude = addviewmodel.Longitude,
                EngineRunTime = addviewmodel.EngineRunTime != null ? TimeSpan.Parse(addviewmodel.EngineRunTime.Replace(".", ":")) : new TimeSpan()


            };

            if (addviewmodel.GasDate != null)
            {
                DateTime dt;
                DateTime.TryParse(addviewmodel.GasDate, out dt);
                gallon.GasDate = dt;
            }else{ gallon.GasDate = DateTime.Now; }
            

            ae.Gallons.Add(gallon);
            int NumberOfChanges = ae.SaveChanges();
           
            return RedirectToAction("JSONList", new { id= addviewmodel.AutoID, viewall = false});
        }

        public ActionResult Edit(int id)
        {  
            return View(ae.Gallons.Where(m => m.ID == id).First());
        }

        [HttpPost]
        public ActionResult Edit(Gallon addviewmodel)
        {

            Gallon gallon = ae.Gallons.Where(m => m.ID == addviewmodel.ID).First();

            gallon.TotalMiles = addviewmodel.TotalMiles;
            gallon.TotalGallons = addviewmodel.TotalGallons;
            gallon.DrivenMiles = addviewmodel.DrivenMiles;
            gallon.TotalPrice = addviewmodel.TotalPrice;
            gallon.TankFilled = addviewmodel.TankFilled;
            gallon.EngineRunTime = addviewmodel.EngineRunTime != null ? TimeSpan.Parse(addviewmodel.EngineRunTime.ToString().Replace(".", ":")) : new TimeSpan();

            if (addviewmodel.GasDate != null)
            {
                //DateTime dt;
                //DateTime.TryParse(addviewmodel.GasDate, out dt);
                gallon.GasDate = addviewmodel.GasDate;
            }
            //else { gallon.GasDate = DateTime.Now; }

            int NumberOfChanges = ae.SaveChanges();

            return RedirectToAction("JSONList", new { id = addviewmodel.AutoID, viewall = false });
        }


        public ActionResult DeleteRow(int milesID)
        {

            var removeGallons = ae.Gallons.First(m => m.ID == milesID);
            
            removeGallons.Delete = true;
            ae.SaveChanges();


            return RedirectToAction("JSONList", new {id = removeGallons.AutoID});
        }

    }
}
