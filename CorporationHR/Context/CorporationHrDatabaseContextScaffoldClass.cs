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
    }
}