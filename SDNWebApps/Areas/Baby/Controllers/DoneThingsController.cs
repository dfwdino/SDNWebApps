using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
                    Actions = thingsDone.Actions,StartTime = thingsDone.StartTime,OZ = thingsDone.OZ,Mood = thingsDone.Mood
                });
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

            _se.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Add()
        {

            AddViewModel test = new AddViewModel();

            return View(new AddViewModel());
        }

        [HttpPost]
        public ActionResult Add(AddViewModel addViewModel)
        {

            //var allErrors = ModelState.Values.SelectMany(v => v.Errors).Where(m => m.ErrorMessage.IndexOf("StartTime")>0);

             //= FixFuckenDate(ModelState["StartTime"].Value.AttemptedValue.ToString());

            if (!ModelState.IsValid)
                return View(addViewModel);


            //is there a better way to do this????
            string action = _se.Actions1.First(m => m.index == addViewModel.Action).Title;
            ThingsDone td = new ThingsDone();

            td.Action = addViewModel.Action;
            td.StartTime = Convert.ToDateTime(FixFuckenDate(addViewModel.StartTime));

            if (addViewModel.EndTime!=null)
                td.EndTime = Convert.ToDateTime(FixFuckenDate(addViewModel.EndTime));

            td.OZ = addViewModel.OZ;

            td.Mood = addViewModel.Mood;
            td.Notes = addViewModel.Notes;


            _se.ThingsDones.Add(td);
            _se.SaveChanges();

            if (action.IndexOf("Feed") >= 0 || action.IndexOf("BF") >= 0)
            {
                return RedirectToAction("Edit", "DoneThings", new { id = td.index });
            }
            else
            {
                return RedirectToAction("Index", "DoneThings", new { id = td.index });
            }

            
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