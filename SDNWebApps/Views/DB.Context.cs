﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SDNAppsEntities : DbContext
    {
        public SDNAppsEntities()
            : base("name=SDNAppsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Gallon> Gallons { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Actions> Actions1 { get; set; }
        public DbSet<ThingsDone> ThingsDones { get; set; }
    }
}