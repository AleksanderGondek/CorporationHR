using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;

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
        }

        public virtual bool Save(T entity)
        {
            DatabaseContext.Add(entity);
            DatabaseContext.SaveChanges();
            return true;
        }

        public virtual void Remove(T entity)
        {
            DatabaseContext.Delete(entity);
            DatabaseContext.SaveChanges();
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

        public string GetClearenceNameFromUserName(string userName)
        {
            var user = DatabaseContext.UserProfiles.Single(x => x.UserName.Equals(userName));
            return user != null ? user.ClearenceModel.ClearenceName : string.Empty;
        }

        public string GetClearenceColorFromUserName(string userName)
        {
            var user = DatabaseContext.UserProfiles.Single(x => x.UserName.Equals(userName));
            return user != null ? user.ClearenceModel.ClearenceRgbColor : string.Empty;
        }
        public int GetCurrentUserClearenceWeight(string userName)
        {
            var user = DatabaseContext.UserProfiles.Single(x => x.UserName.Equals(userName));
            return user != null ? user.ClearenceModel.ClearenceWeight : 99;
        }

        public abstract T Find(int id);
    }
}