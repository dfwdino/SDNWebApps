using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Baby.Models.DoneThings
{
    public class AddViewModel
    {
        public AddViewModel()
        {
            Actions = new SDNWebApps.Views.Actions();
            StartTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "Central Standard Time").ToString(CultureInfo.InvariantCulture);
            EndTime = string.Empty;
            Mood = string.Empty;
            OZ = null;
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
        public float? OZ { get; set; }
        public string Mood { get; set; }
        public string Notes { get; set; }

        public int LiquidType { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
        
    
}