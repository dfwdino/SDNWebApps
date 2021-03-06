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
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Actions> Actions1 { get; set; }
        public DbSet<ThingsDone> ThingsDones { get; set; }
        public DbSet<Dream> Dreams { get; set; }
        public DbSet<ActionCategory> ActionCategories { get; set; }
        public DbSet<LiquidSize> LiquidSizes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<GasNote> GasNotes { get; set; }
        public DbSet<Logging> Loggings { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<ReminderType> ReminderTypes { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
        public DbSet<BabyName> BabyNames { get; set; }
        public DbSet<ItemSize> ItemSizes { get; set; }
        public DbSet<AccessPage> AccessPages { get; set; }
        public DbSet<BlockedIPAddress> BlockedIPAddresses { get; set; }
        public DbSet<CardioItem> CardioItems { get; set; }
        public DbSet<CardioLog> CardioLogs { get; set; }
        public DbSet<WeightLog> WeightLogs { get; set; }
        public DbSet<AutomaticThought> AutomaticThoughts { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Punshment> Punshments { get; set; }
        public DbSet<PunshmentAction> PunshmentActions { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Gallon> Gallons { get; set; }
        public DbSet<GasolineType> GasolineTypes { get; set; }
    }
}
