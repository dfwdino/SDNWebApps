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
    
    public partial class PriceHistory
    {
        public int ID { get; set; }
        public int StoreID { get; set; }
        public decimal Price { get; set; }
        public System.DateTime Date { get; set; }
        public string IPAddress { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int ItemID { get; set; }
    
        public virtual Store Store { get; set; }
        public virtual Item Item { get; set; }
    }
}
