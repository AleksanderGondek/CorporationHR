using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class PatentsRepository : RepositoryPackage<Patent>
    {
        public PatentsRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public override Patent Find(int id)
        {
            return DatabaseContext.Patents.ToList().Find(x => x.PatentId.Equals(id));
        }
    }
}