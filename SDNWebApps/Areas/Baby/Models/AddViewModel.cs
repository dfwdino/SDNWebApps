using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Baby.Models
{
    public class AddViewModel
    {
        public AddViewModel()
        {
            Actions = new Actions();
            StartTime = DateTime.Now.ToString();
            EndTime = string.Empty;
        }

        [Required(ErrorMessage = "Need to pick an action item.")]
        public int Action { get; set; }
        public SDNWebApps.Views.Actions Actions {get;set;}
        [Required(ErrorMessage = "Need to pick an start time.")]
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public float OZ { get; set; }
    }
        
    
}