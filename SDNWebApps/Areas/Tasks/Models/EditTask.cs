using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Tasks.Models
{
    public class EditTask : Task
    {
        
        public EditTask()
        {
            SDNAppsEntities _sen = new SDNAppsEntities();

            Persons = _sen.People.Select(m =>m).ToList();

            //DueDate = DateTime.Now.AddDays(+1).ToShortDateString();


        }

        public List<SDNWebApps.Views.Person> Persons;

        public string Title { get; set; }
        public string DueDate { get; set; }

    }
}