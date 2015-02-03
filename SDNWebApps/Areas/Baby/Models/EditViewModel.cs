using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Baby.Models
{
    public class EditViewModel
    {
        public EditViewModel()
        {
            
        }

        
        public int Index { get; set; }
        [Required(ErrorMessage = "Need to pick an action item.")]
        public int Action { get; set; }
        public SDNWebApps.Views.Actions Actions {get;set;}
        [Required(ErrorMessage = "Need to pick an start time.")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }
        public double? OZ { get; set; }
        public string Mood { get; set; }
        public string Notes { get; set; }
    }
        
    
}