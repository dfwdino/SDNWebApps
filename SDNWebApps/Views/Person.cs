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
    
    public partial class Person
    {
        public Person()
        {
            this.Autos = new HashSet<Auto>();
            this.Tasks = new HashSet<Task>();
            this.Dreams = new HashSet<Dream>();
            this.Sizes = new HashSet<Size>();
            this.AccessPages = new HashSet<AccessPage>();
        }
    
        public int ID { get; set; }
        public string PersonName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<bool> Delete { get; set; }
        public string IPAddress { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Sait { get; set; }
        public string Hash { get; set; }
    
        public virtual ICollection<Auto> Autos { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Dream> Dreams { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<AccessPage> AccessPages { get; set; }
    }
}
