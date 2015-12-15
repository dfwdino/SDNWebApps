using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SDNWebApps.Areas.Gas.Models.Miles;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Gas.Controllers
{
    public class MilesController : Controller
    {
        SDNAppsEntities ae = new SDNAppsEntities();

        public ActionResult List(int id, bool viewall = false)
        {
            ListViewModel lmvModel;

            if (viewall)
            {
                lmvModel = new Models.Miles.ListViewModel(ae.Gallons.Where(m => m.AutoID == id).ToList());
            }
            else
            {
                DateTime backdate = DateTime.Now.AddMonths(-1);
                //lmvModel = new Models.Miles.ListViewModel(ae.Gallons.Where(m => m.AutoID == id && m.GasDate > DbFunctions.TruncateTime(backdate))
                //   .OrderBy(m => m.TotalMiles).ToList()); 
                lmvModel = new Models.Miles.ListViewModel(ae.Gallons.Where(m => m.AutoID == id).OrderByDescending(m => m.TotalMiles)
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
            
            

            return View(lmvModel);
        }

        [HttpPost]
        public ActionResult Add(AddViewModel addviewmodel)
        {
            
            Gallon gallon = new Gallon
            {
                AutoID = addviewmodel.AutoID,
                TotalMiles = (int) (addviewmodel.TotalMiles ?? 0),
                TotalGallons = addviewmodel.TotalGallons ?? 0,
                DrivenMiles = addviewmodel.DrivenMiles ?? 0,
                TotalPrice = addviewmodel.TotalPrice,
                TankFilled = addviewmodel.TankFilled,
                StationID = addviewmodel.SelectedStation
                
            };

            gallon.GasDate = addviewmodel.GasDate.HasValue ? addviewmodel.GasDate : DateTime.Now;

            ae.Gallons.Add(gallon);
            int NumberOfChanges = ae.SaveChanges();
            
            List<Gallon> test = ae.Gallons.Where(m => m.AutoID == addviewmodel.AutoID).ToList();

            ListViewModel lvm = new ListViewModel(test);

            return RedirectToAction("List",new { id= addviewmodel.AutoID, viewall = false});
        }

        public ActionResult DeleteRow(int milesID)
        {

            var removeGallons = ae.Gallons.First(m => m.ID == milesID);


            //ae.Gallons.Remove(removeGallons);
            removeGallons.Delete = true;
            ae.SaveChanges();


            return RedirectToAction("List", new {id = removeGallons.AutoID});
        }

    }
}
