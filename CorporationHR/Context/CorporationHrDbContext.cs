using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CorporationHR.Models;
using WebMatrix.WebData;

namespace CorporationHR.Context
{
    public class CorporationHrDbContext : DbContext, ICorporationHrDatabaseContext
    {
        public CorporationHrDbContext() : base("DefaultConnection") { }
        public CorporationHrDbContext(string connectionString) : base(connectionString) { }
        public CorporationHrDbContext(DbConnection existingConnection, bool ifOwnsConnection) : base(existingConnection, ifOwnsConnection) {  }

        public DbSet<UserProfile> UserProfiles { get; set; }
        IQueryable<UserProfile> ICorporationHrDatabaseContext.UserProfiles { get { return UserProfiles.AsQueryable(); } }

        public T Attach<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public T Add<T>(T entity) where T : class
        {
            return Set<T>().Add(entity);
        }

        public T Delete<T>(T entity) where T : class
        {
            return Set<T>().Remove(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return Set<T>().AsQueryable();
        }
    }

    public class DatabaseInitializator : DbMigrationsConfiguration<CorporationHrDbContext>
    {
        public DatabaseInitializator()
        {
            this.AutomaticMigrationsEnabled = true;
            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        } 
    }
}