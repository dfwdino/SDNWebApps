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
    
    public partial class Item
    {
        public int ID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public bool Have { get; set; }
        public byte[] Image { get; set; }
        public string Amount { get; set; }
        public Nullable<System.DateTime> LastGotten { get; set; }
        public string ImageLocation { get; set; }
    
        public virtual Store Store { get; set; }
    }
}
