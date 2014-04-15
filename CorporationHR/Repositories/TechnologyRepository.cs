using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class TechnologyRepository : RepositoryPackage<Technology>
    {
        public TechnologyRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }



        public override Technology Find(int id)
        {
            var listOfAllTechs = DatabaseContext.Technologies.ToList();
            return listOfAllTechs.Find(x => x.TechnologyId.Equals(id));
        }
    }
}