using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class UseAndPlansRepository : RepositoryPackage<UseAndPlan>
    {
        public UseAndPlansRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public override UseAndPlan Find(int id)
        {
            return DatabaseContext.UseAndPlans.ToList().Find(x => x.UseAndPlanId.Equals(id));
        }
    }
}