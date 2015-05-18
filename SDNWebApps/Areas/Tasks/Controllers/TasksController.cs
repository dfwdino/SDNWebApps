using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI.WebControls;
using SDNWebApps.Areas.Tasks.Models;
using SDNWebApps.Views;
using ModelState = System.Web.Http.ModelBinding.ModelState;

namespace SDNWebApps.Areas.Tasks.Controllers
{
    public class TasksController : Controller
    {
        SDNAppsEntities sdnApps = new SDNAppsEntities();

        [HttpPost]
        [WebMethod]
        public JsonResult GotTask(int taskID)
        {
            var gotItem = sdnApps.Tasks.First(m => m.ID == taskID);

            gotItem.Done = !gotItem.Done;

            //gotItem.Done = done;
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");
        }

        public ActionResult AddTask(string taskName="")
        {

            if (!taskName.Equals(""))
                ViewBag.Task = taskName + " was add.";

            return View(new Models.AddTask());
        }

        public ActionResult EditTask(int taskID)
        {

            EditTask editTask = new EditTask();
            var curentTask = sdnApps.Tasks.FirstOrDefault(m => m.ID == taskID);

            editTask.DueDate = curentTask.DueDate.ToString();
            editTask.Person = curentTask.Person;
            editTask.Title = curentTask.Title;


            return View(editTask);


        }

[HttpPost]        
//TODO: Fix this. Remove field names and use viewmode and retrun to edit or list
        public ActionResult EditTask(EditTask task)
        {
            var currentTask = sdnApps.Tasks.FirstOrDefault(m => m.ID == task.ID);

    currentTask.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(task.Title);
    currentTask.DueDate = Convert.ToDateTime(task.DueDate);
            currentTask.PersonID = task.PersonID;
            
            
            sdnApps.SaveChanges();
            return RedirectToAction("AddTask", new {taskName = task.Title});
            
        }


        [HttpPost]
        ///TODO: Fix this. Remove field names and use viewmode and retrun to edit or list
        public ActionResult AddTask(AddTask task)
        {
            var newTask = sdnApps.Tasks.FirstOrDefault(m => m.Title == task.Title);
            
            newTask = new Task { Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(task.Title), DueDate = Convert.ToDateTime(task.DueDate), Done = false, PersonID = task.PersonID};
            
            sdnApps.Tasks.Add(newTask);
            sdnApps.SaveChanges();
            return RedirectToAction("AddTask", new {taskName = task.Title});
            
        }

        [HttpPost]
        public JsonResult DeleteItem(int taskID)
        {
            var dtask = sdnApps.Tasks.First(m => m.ID == taskID);
            
            sdnApps.Tasks.Remove(dtask);
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");

        }

    }
}
