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
    
    public partial class AccessPage
    {
        public int ID { get; set; }
        public string AccessPage1 { get; set; }
        public bool Disactive { get; set; }
        public int PersonID { get; set; }
    
        public virtual Person Person { get; set; }


        public List<string> SelectedAction { get; set; }
    }
}
