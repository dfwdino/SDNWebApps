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
    
    public partial class GasNote
    {
        public int NotesID { get; set; }
        public string Note { get; set; }
        public int AutoID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string IPAddress { get; set; }
        public string Broswer { get; set; }
        public bool Deleted { get; set; }
        public Nullable<System.DateTime> NoteDate { get; set; }
    
        public virtual Auto Auto { get; set; }
    }
}