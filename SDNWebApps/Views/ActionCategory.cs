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
    
    public partial class ActionCategory
    {
        public ActionCategory()
        {
            this.Actions = new HashSet<Actions>();
        }
    
        public System.Guid Index { get; set; }
        public string Category { get; set; }
    
        public virtual ICollection<Actions> Actions { get; set; }
    }
}