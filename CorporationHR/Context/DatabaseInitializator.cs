using System;
using System.Data.Entity.Migrations;
using System.Drawing;
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
            AddSecurityOfTables(context);
            
            AddTechnologies(context);

            AddClearencesToUsers(context);
            AddClearencesToSecurityOfTables(context);
        }

        private void AttachSimpleAuth()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }

        public void AddSecurityOfTables(CorporationHrDbContext context)
        {
            if (context.SecurityOfTables.ToList().Any()) return;

            var securityOfTablesTable = new SecurityOfTable {TableName = "Security Of Tables"};
            var userProfilesTable = new SecurityOfTable {TableName = "User Profiles"};
            var clearenceModelsTable = new SecurityOfTable {TableName = "Clearence Models"};
            var technologiesModels = new SecurityOfTable {TableName = "Technologies"};

            context.SecurityOfTables.Add(securityOfTablesTable);
            context.SecurityOfTables.Add(userProfilesTable);
            context.SecurityOfTables.Add(clearenceModelsTable);
            context.SecurityOfTables.Add(technologiesModels);

            context.SaveChanges();
        }

        public void AddClearencesToSecurityOfTables(CorporationHrDbContext context)
        {
            var securityOfTables = context.SecurityOfTables.ToList();
            var clearences = context.Clearences.ToList();
            if (securityOfTables.Any(x => x.ClearenceModel != null)) return;

            foreach (var table in securityOfTables)
            {
                switch (table.TableName)
                {
                    case "Security Of Tables":
                        table.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Public"));
                        break;
                    case "User Profiles":
                        table.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Public"));
                        break;
                    case "Clearence Models":
                        table.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Public"));
                        break;
                    case "Technologies":
                        table.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Public"));
                        break;
                    default:
                        break;;
                }

                context.SaveChanges();
            }
        }

        private void AddTechnologies(CorporationHrDbContext context)
        {
            if (context.Technologies.ToList().Any()) return;

            var newPublicTech = new Technology()
                                {
                                    TechnologyInternalId = "This is GUID of some public tech",
                                    ShortDescription = "This is a short description of some public tech",
                                    FullDescription = "This is a long description of some public tech",
                                    CreatedOn = DateTime.Now,
                                    IsCompleted = false
                                };

            var newConfidentialTech = new Technology()
                                      {
                                          TechnologyInternalId = "This is GUID of some confidential tech",
                                          ShortDescription = "This is a short description of some confidential tech",
                                          FullDescription = "This is a long description of some confidential tech",
                                          CreatedOn = DateTime.Now,
                                          IsCompleted = false
                                      };

            var newSecretTech = new Technology()
                                {
                                    TechnologyInternalId = "This is GUID of some secret tech",
                                    ShortDescription = "This is a short description of some secret tech",
                                    FullDescription = "This is a long description of some secret tech",
                                    CreatedOn = DateTime.Now,
                                    IsCompleted = false
                                };

            var newTopSecretTech = new Technology()
                                   {
                                       TechnologyInternalId = "This is GUID of some TopSecret tech",
                                       ShortDescription = "This is a short description of some TopSecret tech",
                                       FullDescription = "This is a long description of some TopSecret tech",
                                       CreatedOn = DateTime.Now,
                                       IsCompleted = false
                                   };

            context.Technologies.Add(newPublicTech);
            context.Technologies.Add(newConfidentialTech);
            context.Technologies.Add(newSecretTech);
            context.Technologies.Add(newTopSecretTech);
            context.SaveChanges();
        }

        private void AddUsers()
        {
            if (!WebSecurity.UserExists("admin")) { WebSecurity.CreateUserAndAccount("admin", "test", new { FirstName = "Admin", LastName = "Admin", Email = "admin@admin.ad"}); }
            if (!WebSecurity.UserExists("userTest1")) { WebSecurity.CreateUserAndAccount("userTest1", "qwerty", new { FirstName = "test1", LastName = "testos1", Email = "test1@test.ts"}); }
            if (!WebSecurity.UserExists("userTest2")) { WebSecurity.CreateUserAndAccount("userTest2", "qwerty", new { FirstName = "test2", LastName = "testos2", Email = "test2@test.ts"}); }
            if (!WebSecurity.UserExists("userTest3")) { WebSecurity.CreateUserAndAccount("userTest3", "qwerty", new { FirstName = "test3", LastName = "testos3", Email = "test3@test.ts" });}
        }

        private void AddClerences(CorporationHrDbContext context)
        {
            var listOfClearencesInDb = context.Clearences.Where(x => x.ClearenceId > 0).ToList(); //Don't ask
            if (listOfClearencesInDb.Any()) { return; }

            var clearenceGreen = new ClearenceModel { ClearenceWeight = 9, ClearenceName = "Public", ClearenceRgbColor = "#00C957" };
            var clearenceOrange = new ClearenceModel { ClearenceWeight = 2, ClearenceName = "Confidential", ClearenceRgbColor = "#00BFFF" };
            var clearenceRed = new ClearenceModel { ClearenceWeight = 1, ClearenceName = "Secret", ClearenceRgbColor = "#EEC900" };
            var clearenceBlack = new ClearenceModel { ClearenceWeight = 0, ClearenceName = "Top Secret", ClearenceRgbColor = "#CD0000" };

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
                if (user.UserName.Equals("userTest3")) { user.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Confidential")); }
                context.SaveChanges();
            }
        }
    }
}