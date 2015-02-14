using System;
using System.ComponentModel.DataAnnotations;

namespace SDNWebApps.Areas.Baby.Models.DoneThings
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