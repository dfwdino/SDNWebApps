using System;
using System.ComponentModel;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Gas.Models.Miles
{
    public class AddViewModel
    {

        public AddViewModel()
        {
           
        }

        public AddViewModel(int autoID)
        {
            AutoID = autoID;
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
        [DisplayName("Gas Date")]
        public DateTime? GasDate  { get; set; }
        [DisplayName("Tank Filled")]
        public bool TankFilled { get; set; }


    }
}