using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using SDNWebApps.Areas.Gas.Controllers;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Gas.Models.Miles
{
    public class AddViewModel
    {
        SDNAppsEntities se = new SDNAppsEntities();
        public AddViewModel() { }

        public AddViewModel(int autoID)
        {
            AutoID = autoID;

            Stations = new SelectList(se.Stations.OrderBy(m => m.StationName), "StationID", "StationName", null);
        }

        public AddViewModel(Gallon gallon)
        {
            AutoID =       gallon.AutoID;
            TotalMiles =   gallon.TotalMiles;
            TotalGallons = gallon.TotalGallons;
            DrivenMiles  = gallon.DrivenMiles;
            TotalPrice =   gallon.TotalPrice;
            GasDate =      gallon.GasDate;
            TankFilled =   gallon.TankFilled;

        }

        public int SelectedStation { get; set; }
        public int AutoID { get; set; }
        //public int PersonID { get; set; }
        [DisplayName("Total Miles")]
        public int? TotalMiles  { get; set; }
        [DisplayName("Total Gallons")]
        public double? TotalGallons  { get; set; }
        [DisplayName("Driven Miles")]
        public int? DrivenMiles { get; set; }
        [DisplayName("Total Price")]
        public decimal? TotalPrice  { get; set; }

        [DataType(DataType.DateTime), Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Gas Date")]
        public DateTime? GasDate  { get; set; }
        
        [DisplayName("Tank Filled")]
        public bool TankFilled { get; set; }

       public SelectList Stations { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }


    }
}