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
    
    public partial class Dream
    {
        public System.Guid ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Dream1 { get; set; }
        public Nullable<int> Person { get; set; }
        public bool DidMeditation { get; set; }
        public bool Deleted { get; set; }
    
        public virtual Person Person1 { get; set; }
    }
}