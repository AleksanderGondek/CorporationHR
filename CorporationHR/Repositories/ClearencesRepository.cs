using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class ClearencesRepository : RepositoryPackage<ClearenceModel>
    {
        public ClearencesRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public override ClearenceModel Find(int id)
        {
            return DatabaseContext.Clearences.ToList().Find(x => x.ClearenceId.Equals(id));
        }
    }
}