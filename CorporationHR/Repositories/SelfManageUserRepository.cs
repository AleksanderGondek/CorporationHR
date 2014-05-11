using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class SelfManageUserRepository : RepositoryPackage<UserProfile>
    {
        public SelfManageUserRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public override UserProfile Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}