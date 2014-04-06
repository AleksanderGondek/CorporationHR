using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using CorporationHR.Helpers;
using CorporationHR.Models;
using WebMatrix.WebData;

namespace CorporationHR.Context
{
    public class DatabaseInitializator : DbMigrationsConfiguration<CorporationHrDbContext>
    {
        public DatabaseInitializator()
        {
            this.AutomaticMigrationsEnabled = true;;
        }

        protected override void Seed(CorporationHrDbContext context)
        {
            AttachSimpleAuth();
            AddUsers();
            AddClerences(context);
            AddClearencesToUsers(context);
        }

        private void AttachSimpleAuth()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }

        private void AddUsers()
        {
            var roles = (SimpleRoleProvider) Roles.Provider;
            if (!roles.RoleExists("Active")) roles.CreateRole("Active");
            if (!roles.RoleExists("Disabled")) roles.CreateRole("Disabled");
            
            if (!WebSecurity.UserExists("admin")) { WebSecurity.CreateUserAndAccount("admin", "test", new { FirstName = "Admin", LastName = "Admin", Email = "admin@admin.ad"}); }
            if (!WebSecurity.UserExists("userTest1")) { WebSecurity.CreateUserAndAccount("userTest1", "qwerty", new { FirstName = "test1", LastName = "testos1", Email = "test1@test.ts"}); }
            if (!WebSecurity.UserExists("userTest2"))
            {
                WebSecurity.CreateUserAndAccount("userTest2", "qwerty", new { FirstName = "test2", LastName = "testos2", Email = "test2@test.ts"});
                roles.AddUsersToRoles(new[] { "admin", "userTest1", "userTest2" }, new[] { "Active" });
            }

        }

        private void AddClerences(CorporationHrDbContext context)
        {
            var listOfClearencesInDb = context.Clearences.Where(x => x.ClearenceId > 0).ToList(); //Don't ask
            if (listOfClearencesInDb.Any())
            {
                listOfClearencesInDb.ForEach(x => GeneralHelper.Clearences.Add(x.ClearenceId, x.ClearenceName));
                return;
            }

            var clearenceGreen = new ClearenceModel { ClearenceName = "Public" };
            var clearenceOrange = new ClearenceModel { ClearenceName = "Confidential" };
            var clearenceRed = new ClearenceModel { ClearenceName = "Secret" };
            var clearenceBlack = new ClearenceModel { ClearenceName = "Top Secret" };

            context.Clearences.Add(clearenceGreen);
            context.Clearences.Add(clearenceOrange);
            context.Clearences.Add(clearenceRed);
            context.Clearences.Add(clearenceBlack);
            context.SaveChanges();
        }

        private void AddClearencesToUsers(CorporationHrDbContext context)
        {
            var users = context.UserProfiles.ToList();
            var clearences = context.Clearences.ToList();
            if (!users.Any() || !clearences.Any()) return;

            foreach (var user in users)
            {
                user.ClearenceModel = !user.UserName.Equals("admin") ? clearences.Single(x => x.ClearenceName.Equals("Public")) : clearences.Single(x => x.ClearenceName.Equals("Top Secret"));
                context.SaveChanges();
            }
        }
    }
}