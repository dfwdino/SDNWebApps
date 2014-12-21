using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Tasks.Models
{
    public class Task1 : Task
    {
        
        public Task1()
        {
            SDNAppsEntities _sen = new SDNAppsEntities();

            Persons = _sen.People.Select(m =>m).ToList();

            DueDate = DateTime.Now.AddDays(+1).ToShortDateString();


        }

        public List<SDNWebApps.Views.Person> Persons;

        public string DueDate { get; set; }

    }
}