//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDNWebApps.Views
{
    using System;
    using System.Collections.Generic;
    
    public partial class Punshment
    {
        public int index { get; set; }
        public Nullable<int> BabyNameID { get; set; }
        public int PunshmentActions { get; set; }
        public System.DateTime StartTime { get; set; }
        public bool Delete { get; set; }
        public string Notes { get; set; }
        public string IPAddress { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Nullable<int> LiquidSizeID { get; set; }
    
        public virtual BabyName BabyName { get; set; }
        public virtual PunshmentAction PunshmentAction { get; set; }
    }
}
