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

        public void AddClearenceToNewlyCreatedUser(string userName)
        {
            var user = DatabaseContext.UserProfiles.Single(x => x.UserName.Equals(userName));
            if (user == null) return;

            user.ClearenceModel = DatabaseContext.Clearences.Single(x => x.ClearenceName.Equals("Normal"));
            DatabaseContext.Attach(user);
            DatabaseContext.SaveChanges();
        }

        public override UserProfile Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}