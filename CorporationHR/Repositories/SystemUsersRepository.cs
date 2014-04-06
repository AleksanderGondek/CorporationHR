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
            return DatabaseContext.UserProfiles.ToList().Select(profile => new AdminUserProfileModel(profile)).ToList();
        }

        public void AdminUpdate(AdminUserProfileModel userModel)
        {
            var entity = DatabaseContext.UserProfiles.ToList().Single(x => x.UserId.Equals(userModel.UserId));
            if (entity == null) return;

            entity.UserName = userModel.UserName;
            entity.FirstName = userModel.FirstName;
            entity.LastName = userModel.LastName;
            entity.Email = userModel.Email;

            var selectedClearance = DatabaseContext.Clearences.ToList().Single(x => x.ClearenceId.Equals(userModel.SelectedClearanceId));
            if (selectedClearance != null) entity.ClearenceModel = selectedClearance; 

            DatabaseContext.SaveChanges();
        }

        public void Remove(int userId)
        {
            var entityToRemoval = DatabaseContext.UserProfiles.ToList().Single(x => x.UserId.Equals(userId));
            if (entityToRemoval == null) return;
            var userRoles = Roles.GetRolesForUser(entityToRemoval.UserName);
            Roles.RemoveUserFromRoles(entityToRemoval.UserName, userRoles);
            DatabaseContext.Delete(entityToRemoval);
            DatabaseContext.SaveChanges();
        }

        public override UserProfile Find(int id)
        {
            return DatabaseContext.UserProfiles.ToList().Single(x => x.UserId == id);
        }
    }
}