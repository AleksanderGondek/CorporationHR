using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CorporationHR.Models;

namespace CorporationHR.Context
{
    public class CorporationHrDbContext : DbContext, ICorporationHrDatabaseContext
    {
        public CorporationHrDbContext() : base("DefaultConnection") { }
        public CorporationHrDbContext(string connectionString) : base(connectionString) { }
        public CorporationHrDbContext(DbConnection existingConnection, bool ifOwnsConnection) : base(existingConnection, ifOwnsConnection) {  }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ClearenceModel> Clearences { get; set; }

        IQueryable<UserProfile> ICorporationHrDatabaseContext.UserProfiles { get { return UserProfiles.AsQueryable(); } }
        IQueryable<ClearenceModel> ICorporationHrDatabaseContext.Clearences { get { return Clearences.AsQueryable(); } } 

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
}