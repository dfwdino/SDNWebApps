using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using SDNWebApps.Areas.Baby.Models;
using SDNWebApps.Areas.Baby.Models.DoneThings;
using SDNWebApps.Views;
using System.Data.Entity;


namespace SDNWebApps.Areas.Baby.Controllers
{
    public class DoneThingsController : Controller
    {
        
        SDNAppsEntities _se = new SDNAppsEntities();

        public ActionResult SummaryPage()
        {
            var makeSummary =
                _se.ThingsDones.Where(m => m.Actions.ActionCategory.Category == "Food" && (m.OZ > 0 || m.OZ != null))
                    .GroupBy(g => new {TruncateTime = EntityFunctions.TruncateTime(g.StartTime)})
                    .Select(s => new {StartTime = s.Key.TruncateTime, OZ = s.Sum(item => item.OZ)}).ToList();

            var smList = makeSummary.Select(summary => new SummaryModel((DateTime)summary.StartTime,summary.OZ)).ToList();


            return View(smList);
        }

        public ActionResult SummaryPage2()
        {
            DateTime backDate = DateTime.Now.AddDays(-3);
            var Grouped = _se.ThingsDones.Where(m => m.StartTime > backDate)
                                            .GroupBy(m => new {TruncateTime = EntityFunctions.TruncateTime(m.StartTime), m.Actions.Title})
                                            .Select(s => new {ItemDate = s.Key.TruncateTime, Title = s.Key.Title, Count = s.Count(),TotalOZ = s.Sum(ss => ss.OZ)})
                                            .OrderByDescending(m => m.ItemDate);
                            
            List<SummaryModel2> smList = new List<SummaryModel2>();

            foreach (var done in Grouped)
            {
                SummaryModel2 sm = new SummaryModel2() {ItemDate = done.ItemDate,Title = done.Title, action = done.Count,OZ = done.TotalOZ};
                smList.Add(sm);
            }
            
            return View(smList);
        }



        public ActionResult Index(bool viewall = false)
        {
            List<Views.ThingsDone> things =  new List<ThingsDone>();

            if(viewall)
                things = _se.ThingsDones.OrderByDescending(m => m.StartTime).Where(m => m.Delete == false).Select(m => m).ToList();
                //things = _se.ThingsDones.OrderBy(m => m.Actions.Title).ThenByDescending(m => m.StartTime)
                //    .Where(m => m.Delete == false).Select(m => m).ToList();
            else
            {
                //Why is it not showing any data for the last day??? Where is my logic wrong???
                DateTime mindate = DateTime.Now.AddDays(-3).Date;

                things = _se.ThingsDones.OrderByDescending(m => m.StartTime).Where(m => m.Delete == false 
                            && m.StartTime > mindate).Select(m => m).ToList();

                //things = _se.ThingsDones.OrderByDescending(m => DbFunctions.TruncateTime(m.StartTime)).ThenBy(m => m.Actions.index).ThenByDescending(m => m.StartTime)
                //            .Where(m => m.Delete == false).Select(m => m).ToList();
            }


            //Why i am doing it this way????
            var _things = new List<ListViewModel>();

            foreach (var thingsDone in things)
            {
                _things.Add(new ListViewModel
                {
                    EndTime = thingsDone.EndTime, Item = thingsDone.index,Index = thingsDone.index, Notes = thingsDone.Notes,
                    Actions = thingsDone.Actions,StartTime = thingsDone.StartTime,OZ = thingsDone.OZ,Mood = thingsDone.Mood,
                    LiquidSize = thingsDone.LiquidSize, Longitude = thingsDone.Longitude, Latitude = thingsDone.Latitude

                });
            }

            if (Request.Cookies["LoggedIn"] != null)
            {
                HttpCookie myCookie = new HttpCookie("LoggedIn");
                myCookie.Expires = DateTime.Now.AddDays(1d);

                Response.Cookies.Add(myCookie);


                HttpCookie idCookie = new HttpCookie("SDNID");
                idCookie.Expires = DateTime.Now.AddDays(1d);

                Response.Cookies.Add(idCookie);
            }




            return View(_things);
        }

        public ActionResult IndexV2(bool viewall = false)
        {
            List<Views.ThingsDone> things = new List<ThingsDone>();

            if (viewall)
                things = _se.ThingsDones.OrderByDescending(m => m.StartTime).Where(m => m.Delete == false).Select(m => m).ToList();
            //things = _se.ThingsDones.OrderBy(m => m.Actions.Title).ThenByDescending(m => m.StartTime)
            //    .Where(m => m.Delete == false).Select(m => m).ToList();
            else
            {
                DateTime mindate = DateTime.Now.AddDays(-3);

                //things = _se.ThingsDones.OrderByDescending(m => m.StartTime).ThenByDescending(m => m.StartTime).Where(m => m.Delete == false
                //            && m.StartTime > mindate).Select(m => m).ToList();

                things = _se.ThingsDones.OrderByDescending(m => DbFunctions.TruncateTime(m.StartTime))
                              .ThenBy(m => m.Actions.index).ThenByDescending(m => m.StartTime)
                            .Where(m => m.Delete == false).Select(m => m).ToList();
            }


            //Why i am doing it this way????
            var _things = new List<ListViewModel>();

            foreach (var thingsDone in things)
            {
                _things.Add(new ListViewModel
                {
                    EndTime = thingsDone.EndTime,
                    Item = thingsDone.index,
                    Index = thingsDone.index,
                    Actions = thingsDone.Actions,
                    StartTime = thingsDone.StartTime,
                    OZ = thingsDone.OZ
                });
            }




            return View(_things);
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditViewModel editAddViewModel = new EditViewModel();
            ThingsDone thing = _se.ThingsDones.FirstOrDefault(m => m.index == id);
            editAddViewModel.Index = thing.index;
            editAddViewModel.Action = thing.Action;
            editAddViewModel.Actions = thing.Actions;
            //if(thing.EndTime == null && (thing.Actions.Title.IndexOf("Feed", System.StringComparison.CurrentCultureIgnoreCase) >=0 
                    //|| thing.Actions.Title.IndexOf("BF", System.StringComparison.CurrentCultureIgnoreCase) >=0))
            //{
            //    editAddViewModel.EndTime = DateTime.Now.AddMinutes(30);
            //}
            //if (thing.EndTime == null && thing.Actions.Title.IndexOf("Sleep", System.StringComparison.CurrentCultureIgnoreCase) >= 0)
            //{
            //    editAddViewModel.EndTime = DateTime.Now;
            //}
            if(thing.EndTime != null)
            {
                editAddViewModel.EndTime = thing.EndTime;
            }
            editAddViewModel.StartTime = thing.StartTime;
            editAddViewModel.OZ = thing.OZ;
            editAddViewModel.Mood = thing.Mood;
            editAddViewModel.Notes = thing.Notes;
            editAddViewModel.LiquidType = thing.LiquidSizeID;


            return View(editAddViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel editViewModel)
        {
            var td = _se.ThingsDones.First(m => m.index == editViewModel.Index);
   
            td.Action = editViewModel.Action;
            td.StartTime = editViewModel.StartTime;

            if (editViewModel.EndTime == null  && ModelState["EndTime"].Value != null)
            {
                var etempDT =
                    ModelState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                        .ToArray()
                        .First(m => m.Key == "EndTime")
                        .Value.Value.AttemptedValue;
                if (!etempDT.Length.Equals(0))
                {
                    var try2 = FixFuckenDate(etempDT);

                    td.EndTime = try2;
                }
            }
            else
            {
                td.EndTime = editViewModel.EndTime;
            }
            td.OZ = editViewModel.OZ;
            td.Mood = editViewModel.Mood;
            td.Notes = editViewModel.Notes;
            td.LiquidSizeID = editViewModel.LiquidType;

            _se.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Add()
        {

            AddViewModel test = new AddViewModel();

            return View(new AddViewModel());
        }

        [HttpPost]
        public ActionResult Add(AddViewModel addViewModel,FormCollection form)
        {

            var Actions = form["Action"].Split(',');
            var LiquidTypes = form["POS"].Split(','); //Fucken MS bad coding, this value is "LiquidType"
            var OZs = form["OZ"].Split(',');

            if (!ModelState.IsValid)
                return View(addViewModel);

            ThingsDone td;

            for (int i = 0; i < Actions.Count(); i++)
            {
                td = new ThingsDone();

                td.Action = Convert.ToInt16(Actions[i]);
                td.StartTime = Convert.ToDateTime(FixFuckenDate(addViewModel.StartTime));

                if (addViewModel.EndTime != null)
                    td.EndTime = Convert.ToDateTime(FixFuckenDate(addViewModel.EndTime));

                if(!OZs[i].Length.Equals(0))
                    td.OZ = Convert.ToDouble(OZs[i]); //might need to check for null


                if (i == 0)
                {
                    td.Notes = addViewModel.Notes;
                    td.Latitude = addViewModel.Latitude;
                    td.Longitude = addViewModel.Longitude;
                }


                td.LiquidSizeID = Convert.ToInt16(LiquidTypes[i]); //might need to check for null


                _se.ThingsDones.Add(td);
            }
            


            ////is there a better way to do this????
            //string action = _se.Actions1.First(m => m.index == addViewModel.Action).Title;
            //ThingsDone td = new ThingsDone();

            //td.Action = addViewModel.Action;
            //td.StartTime = Convert.ToDateTime(FixFuckenDate(addViewModel.StartTime));

            //if (addViewModel.EndTime!=null)
            //    td.EndTime = Convert.ToDateTime(FixFuckenDate(addViewModel.EndTime));

            //td.OZ = addViewModel.OZ;

            //td.Mood = addViewModel.Mood;
            //td.Notes = addViewModel.Notes;
            //td.LiquidSizeID = addViewModel.LiquidType;


            //_se.ThingsDones.Add(td);
            _se.SaveChanges();

            //is there a better way to do this????
            //No longer doing this with the new way
            //string action = _se.Actions1.First(m => m.index == addViewModel.Action).Title;

            //if (action.IndexOf("Feed") >= 0 || action.IndexOf("BF") >= 0)
            //{
            //    return RedirectToAction("Edit", "DoneThings", new { id = td.index });
            //}
            //else
            //{
            //    return RedirectToAction("Index", "DoneThings", new { id = td.index });
            //}

            return RedirectToAction("Index", "DoneThings");

        }

        
        public ActionResult Delete(int id)
        {
            var thingdone = _se.ThingsDones.First(m => m.index == id);
            thingdone.Delete = true;
            _se.SaveChanges();

            return RedirectToAction("Index");
        }

        private DateTime? FixFuckenDate(string datetime)
        {
            //var sSpace = datetime.Split(' ');
            //var sDate = sSpace[0].Split('/');
            //var sTime = sSpace[1].Split(':');

            //var time = sDate[0].Trim() + "/" + sDate[1].Trim() + "/" + sDate[2].Trim() + " " + (sSpace[2].Trim().Equals("PM", StringComparison.CurrentCultureIgnoreCase) ? sTime[0].Trim() : sTime[0].Trim()) + ":" + sTime[1].Trim() + ":" + sTime[2].Trim() + " " + sSpace[2];

            if (datetime.Length.Equals(0))
                return null;

            var newstr = new string(datetime.Where(c => c < 128).ToArray());

            return DateTime.Parse(newstr, new CultureInfo("en-US"),DateTimeStyles.None);


            //return new DateTime(sDate[2], sDate[1], sDate[0], sSpace[2].Equals("PM",StringComparison.CurrentCultureIgnoreCase) ? sTime[0]+12 : sTime[0], sTime[1], sTime[2], sTime[3]);
            //return new DateTime(Convert.ToInt16(sDate[2]), Convert.ToInt16(sDate[1]), Convert.ToInt16(sDate[0]), 
            //    sSpace[2].Equals("PM", StringComparison.CurrentCultureIgnoreCase) ? Convert.ToInt16(sTime[0]) + 12 : Convert.ToInt16(sTime[0]), 
            //                                Convert.ToInt16(sTime[1]), Convert.ToInt16(sTime[2]), Convert.ToInt16(sTime[3]));


        }

    }
}