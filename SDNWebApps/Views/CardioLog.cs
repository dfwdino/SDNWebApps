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
    
    public partial class CardioLog
    {
        public int ID { get; set; }
        public int CardioItemID { get; set; }
        public decimal Time { get; set; }
        public int CaloriesBurned { get; set; }
        public System.DateTime WorkoutDate { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public bool Deleted { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<decimal> Distance { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual CardioItem CardioItem { get; set; }
    }
}