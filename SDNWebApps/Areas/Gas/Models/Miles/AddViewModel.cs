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

            var test = se.Gallons.Include("Stations")
                .Where(m => m.Station.StationName.Length > 1)
                .GroupBy(m => new { m.StationID, m.Station.StationName })
                .Select(group =>
                        new
                        {
                            StationID = group.Key,
                            StationName = group.Key.StationName,
                            Count = group.Count()
                        })
                .OrderByDescending(group => group.Count).ToList();


            var GasolineType = se.GasolineTypes
                .Select(group =>
                        new
                        {
                            TypeID = group.ID,
                            TypeName = group.TypeName
                        })
                .OrderByDescending(group => group.TypeName).ToList();


            Stations = new SelectList(test, "StationID.StationID", "StationName", null);
            GasTypes = new SelectList(GasolineType, "TypeID", "TypeName", null);
            //Stations = new SelectList(se.Stations.OrderBy(m => m.StationName), "StationID", "StationName", null);
            username = se.Autos.Where(m => m.ID == autoID).Select(m => m.Person.PersonName).First();
        }

        public AddViewModel(Gallon gallon)
        {
            AutoID =       gallon.AutoID;
            TotalMiles =   gallon.TotalMiles;
            TotalGallons = gallon.TotalGallons;
            DrivenMiles  = gallon.DrivenMiles;
            TotalPrice =   gallon.TotalPrice;
            GasDate =      gallon.GasDate.ToString();
            TankFilled =   gallon.TankFilled;
            EngineRunTime = string.Empty;

        }

        public int SelectedStation { get; set; }
        public int SelectedGasType { get; set; }
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
        public string GasDate  { get; set; }
        
        [DisplayName("Tank Filled")]
        public bool TankFilled { get; set; }

       public SelectList Stations { get; set; }
        public SelectList GasTypes { get; set; }


        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public string EngineRunTime { get; set; }

        public string username { get; set; }

        public int GasolineTypeID { get; set; }

    }
}