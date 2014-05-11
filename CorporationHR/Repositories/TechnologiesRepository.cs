using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class TechnologiesRepository : RepositoryPackage<Technology>
    {
        public TechnologiesRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public override Technology Find(int id)
        {
            return DatabaseContext.Technologies.ToList().Find(x => x.TechnologyId.Equals(id));
        }
    }
}