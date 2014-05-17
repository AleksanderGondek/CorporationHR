using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Helpers;

namespace CorporationHR.Repositories
{
    public abstract class RepositoryPackage<T> where T : class
    {
        public RepositoryPackage(ICorporationHrDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
        
        protected ICorporationHrDatabaseContext DatabaseContext;
        
        public List<T> All
        {
            get
            {
                var all = new List<T>();
                try { all = DatabaseContext.All<T>().ToList(); }
                catch { }
                return all;
            }
        }

        public IQueryable<T> Query
        {
            get { return DatabaseContext.All<T>(); }
        }

        public virtual void Update(T entity)
        {
            DatabaseContext.Attach(entity);
            DatabaseContext.SaveChanges();
            ClereancesHelper.Instance.ReloadContext();
        }

        public virtual bool Save(T entity)
        {
            DatabaseContext.Add(entity);
            DatabaseContext.SaveChanges();
            ClereancesHelper.Instance.ReloadContext();
            return true;
        }

        public virtual void Remove(T entity)
        {
            DatabaseContext.Delete(entity);
            DatabaseContext.SaveChanges();
            ClereancesHelper.Instance.ReloadContext();
        }

        public virtual void Dispose()
        {
            if (DatabaseContext == null) return;
            var toDispose = DatabaseContext as CorporationHrDbContext;
            if (toDispose != null) toDispose.Dispose();
        }

        public void Add(T entity)
        {
            DatabaseContext.Add(entity);
        }

        public void Attach(T entity)
        {
            DatabaseContext.Attach(entity);
        }

        public abstract T Find(int id);
    }
}