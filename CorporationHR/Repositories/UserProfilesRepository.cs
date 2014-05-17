using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;
using WebMatrix.WebData;

namespace CorporationHR.Repositories
{
    public class UserProfilesRepository : RepositoryPackage<UserProfile>
    {
        public UserProfilesRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public bool Save(RegisterModel userProfile)
        {
            if (userProfile == null) return false;
            WebSecurity.CreateUserAndAccount(userProfile.UserName, userProfile.Password, new { FirstName = userProfile.FirstName, LastName = userProfile.LastName, Email = userProfile.Email });

            var user = DatabaseContext.UserProfiles.Single(x => x.UserName.Equals(userProfile.UserName));
            if (user == null) return false;

            user.ClearenceModel = DatabaseContext.Clearences.Single(x => x.ClearenceName.Equals("Normal"));
            
            DatabaseContext.Attach(user);
            DatabaseContext.SaveChanges();
            return true;
        }

        public override void Update(UserProfile entity)
        {
            base.Update(entity);

            if (entity.SelectedClearenceId > 0)
            {
                var user = DatabaseContext.UserProfiles.Single(x => x.UserId.Equals(entity.UserId));
                user.ClearenceModel = DatabaseContext.Clearences.Single(x => x.ClearenceId.Equals(entity.SelectedClearenceId));
                DatabaseContext.Attach(user);
                DatabaseContext.SaveChanges(); 
            }
        }

        public override UserProfile Find(int id)
        {
            return DatabaseContext.UserProfiles.ToList().Find(x => x.UserId.Equals(id));
        }
    }
}