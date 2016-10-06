using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Baby.Models.DoneThings
{
    public class EditViewModel
    {
        public EditViewModel()
        {
            SDNAppsEntities saEntities = new SDNAppsEntities();
            BabyName = new BabyName();
            KidNames = new SelectList(saEntities.BabyNames, "ID", "BabyName1");
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
        public int? LiquidType { get; set; }
        public int Kid { get; set; }
        public BabyName BabyName { get; set; }

        [Display(Name = "Kid")]
        public SelectList KidNames { get; set; }
    }

    
        
    
}