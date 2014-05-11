using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Models;

namespace CorporationHR.Context
{
    public interface ICorporationHrDatabaseContext
    {
        //Db Columns
        IQueryable<UserProfile> UserProfiles { get; }
        IQueryable<ClearenceModel> Clearences { get; }
        IQueryable<SecurityOfTable> SecurityOfTables { get; }
        IQueryable<Technology> Technologies { get; } //Db operations
        IQueryable<TechnologyAuthor> TechnologyAuthors { get; }
        T Attach<T>(T entity) where T : class;
        T Add<T>(T entity) where T : class;
        T Delete<T>(T entity) where T : class;
        IQueryable<T> All<T>() where T : class;

        // Db Save Changes
        int SaveChanges();
    }
}