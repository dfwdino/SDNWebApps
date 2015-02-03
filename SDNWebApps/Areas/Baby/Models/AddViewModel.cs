using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
            StartTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            EndTime = string.Empty;
            Mood = string.Empty;
        }

        [Required(ErrorMessage = "Need to pick an action item.")]
        public int Action { get; set; }
        [Display(Name = "Action")]
        public SDNWebApps.Views.Actions Actions {get;set;}
        [Required(ErrorMessage = "Need to pick an start time.")]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [Display(Name = "End Time")]
        public string EndTime { get; set; }
        public float OZ { get; set; }
        public string Mood { get; set; }
        public string Notes { get; set; }
    }
        
    
}