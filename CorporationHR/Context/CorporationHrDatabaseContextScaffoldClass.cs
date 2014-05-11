using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CorporationHR.Models;

namespace CorporationHR.Context
{
    public class CorporationHrDatabaseContextScaffoldClass : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ClearenceModel> Clearences { get; set; }
        public DbSet<SecurityOfTable> SecurityOfTables { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<TechnologyAuthor> TechnologyAuthors { get; set; }
        public DbSet<UseAndPlan> UseAndPlans { get; set; }
        public DbSet<Patent> Patents { get; set; }
    }
}