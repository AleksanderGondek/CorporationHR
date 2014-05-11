using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class SecurityOfTablesRepository : RepositoryPackage<SecurityOfTable>
    {
        public SecurityOfTablesRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public override SecurityOfTable Find(int id)
        {
            return DatabaseContext.SecurityOfTables.ToList().Find(x => x.TableId.Equals(id));
        }
    }
}