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
    
    public partial class GasolineType
    {
        public GasolineType()
        {
            this.Gallons = new HashSet<Gallon>();
        }
    
        public int ID { get; set; }
        public string TypeName { get; set; }
    
        public virtual ICollection<Gallon> Gallons { get; set; }
    }
}