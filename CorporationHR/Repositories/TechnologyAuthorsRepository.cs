using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class TechnologyAuthorsRepository : RepositoryPackage<TechnologyAuthor>
    {
        public TechnologyAuthorsRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public override TechnologyAuthor Find(int id)
        {
            return DatabaseContext.TechnologyAuthors.ToList().Find(x => x.TechnologyAuthorId.Equals(id));
        }
    }
}