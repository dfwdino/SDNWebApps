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
    
    public partial class PunshmentAction
    {
        public PunshmentAction()
        {
            this.Punshments = new HashSet<Punshment>();
        }
    
        public int index { get; set; }
        public string Title { get; set; }
        public bool Delete { get; set; }
        public string IPAddress { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    
        public virtual ICollection<Punshment> Punshments { get; set; }
    }
}
