using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class SimpleUserRepository : RepositoryPackage<UserProfile>
    {
        public SimpleUserRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public string GetCurrentUserClearence(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return string.Empty;
            var currentUser = DatabaseContext.UserProfiles.ToList().Single(x => x.UserName.Equals(userName));
            return currentUser.ClearenceModel.ClearenceName;
        }

        public override UserProfile Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}