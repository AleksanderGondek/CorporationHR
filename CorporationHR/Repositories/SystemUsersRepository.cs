using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class SystemUsersRepository : RepositoryPackage<UserProfile>
    {
        public SystemUsersRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public new List<AdminUserProfileModel> All()
        {
            var toBeReturned = new List<AdminUserProfileModel>();

            foreach (var profile in DatabaseContext.UserProfiles)
            {
                toBeReturned.Add(new AdminUserProfileModel(profile));
            }

            return toBeReturned;
        }

        public void AdminUpdate(AdminUserProfileModel userModel)
        {
            var entity = DatabaseContext.UserProfiles.Single(x => x.UserId.Equals(userModel.UserId));
            if (entity == null) return;

            entity.UserName = userModel.UserName;
            entity.FirstName = userModel.FirstName;
            entity.LastName = userModel.LastName;
            entity.Email = userModel.Email;

            DatabaseContext.SaveChanges();
        }

        public void Remove(int userId)
        {
            var entityToRemoval = DatabaseContext.UserProfiles.Single(x => x.UserId.Equals(userId));
            if (entityToRemoval == null) return;
            var userRoles = Roles.GetRolesForUser(entityToRemoval.UserName);
            Roles.RemoveUserFromRoles(entityToRemoval.UserName, userRoles);
            DatabaseContext.Delete(entityToRemoval);
            DatabaseContext.SaveChanges();
        }

        public override UserProfile Find(int id)
        {
            return DatabaseContext.UserProfiles.Single(x => x.UserId == id);
        }
    }
}