using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class UserProfilesRepository : RepositoryPackage<UserProfile>
    {
        public UserProfilesRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public override UserProfile Find(int id)
        {
            return DatabaseContext.UserProfiles.ToList().Find(x => x.UserId.Equals(id));
        }
    }
}