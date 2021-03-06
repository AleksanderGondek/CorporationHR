﻿using System;
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
            AddTechnologyAuthors(context);
            AddUsesAndPlans(context);
            AddPatents(context);

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
            var technologyAuthorsTable = new SecurityOfTable { TableName = "TechnologyAuthors" };
            var usesAndPlansTable = new SecurityOfTable {TableName = "UsesAndPlans"};
            var patentsTable = new SecurityOfTable {TableName = "Patents"};

            context.SecurityOfTables.Add(securityOfTablesTable);
            context.SecurityOfTables.Add(userProfilesTable);
            context.SecurityOfTables.Add(clearenceModelsTable);
            context.SecurityOfTables.Add(technologiesModels);
            context.SecurityOfTables.Add(technologyAuthorsTable);
            context.SecurityOfTables.Add(usesAndPlansTable);
            context.SecurityOfTables.Add(patentsTable);

            context.SaveChanges();
        }

        public void AddClearencesToSecurityOfTables(CorporationHrDbContext context)
        {
            var securityOfTables = context.SecurityOfTables.ToList();
            var clearences = context.Clearences.ToList();
            if (securityOfTables.All(x => x.ClearenceModel != null)) return;

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
                        table.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Normal"));
                        break;
                    case "TechnologyAuthors":
                        table.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Confidential"));
                        break;
                    case "UsesAndPlans":
                        table.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Secret"));
                        break;
                    case "Patents":
                        table.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Top Secret"));
                        break;
                    default:
                        break;;
                }

                context.SaveChanges();
            }
        }

        public void AddPatents(CorporationHrDbContext context)
        {
            if (context.Patents.ToList().Any()) return;

            var newPatent1 = new Patent()
                            {
                                PatentName = "Patent1 example",
                                PatentText = "Patent1 description!"
                            };
            var newPatent2 = new Patent()
                            {
                                PatentName = "Patent2 example",
                                PatentText = "Patent2 description!"
                            };
            var newPatent3 = new Patent()
                            {
                                PatentName = "Patent3 example",
                                PatentText = "Patent3 description!"
                            };
            var newPatent4 = new Patent()
                            {
                                PatentName = "Patent4 example",
                                PatentText = "Patent4 description!"
                            };

            context.Patents.Add(newPatent1);
            context.Patents.Add(newPatent2);
            context.Patents.Add(newPatent3);
            context.Patents.Add(newPatent4);
            context.SaveChanges();
        }

        public void AddUsesAndPlans(CorporationHrDbContext context)
        {
            if (context.UseAndPlans.ToList().Any()) return;

            var useAndPlan1 = new UseAndPlan
                             {
                                 Abstract = "Abstract1",
                                 CompetitionPlans = "Blah blah plans of competitions",
                                 FuturePlans = "Some future plans",
                                 Usages = "Usages, usages, usages",
                             };
            var useAndPlan2 = new UseAndPlan
                            {
                                Abstract = "Abstract2",
                                CompetitionPlans = "Blah blah plans of competitions",
                                FuturePlans = "Some future plans",
                                Usages = "Usages, usages, usages",
                            };
            var useAndPlan3 = new UseAndPlan
                            {
                                Abstract = "Abstract3",
                                CompetitionPlans = "Blah blah plans of competitions",
                                FuturePlans = "Some future plans",
                                Usages = "Usages, usages, usages",
                            };
            var useAndPlan4 = new UseAndPlan
                            {
                                Abstract = "Abstract4",
                                CompetitionPlans = "Blah blah plans of competitions",
                                FuturePlans = "Some future plans",
                                Usages = "Usages, usages, usages",
                            };

            context.UseAndPlans.Add(useAndPlan1);
            context.UseAndPlans.Add(useAndPlan2);
            context.UseAndPlans.Add(useAndPlan3);
            context.UseAndPlans.Add(useAndPlan4);
            context.SaveChanges();
        }

        public void AddTechnologyAuthors(CorporationHrDbContext context)
        {
            if (context.TechnologyAuthors.ToList().Any()) return;

            var employeeOne = new TechnologyAuthor
                              {
                                  CorpoId = "Some corpo Id",
                                  SocialSecurityNumber = "Some social security number",
                                  FirstName = "First name simply",
                                  Middlename = "Some middle name",
                                  Familyname = "Family name this is",
                                  CorporateEmail = "corpo@email.corpo.eu",
                                  CorporatePhoneNumber = "+48000000011",
                                  FullCorespondenceAdress = "This is full corespondence adress",
                                  FullCurrentAdress = "This is full current adress",
                                  PrivateEmail = "private@email.something.com",
                                  PrivatePhoneNumber = "+48000000000"
                              };

            context.TechnologyAuthors.Add(employeeOne);
            context.SaveChanges();
        }

        private void AddTechnologies(CorporationHrDbContext context)
        {
            if (context.Technologies.ToList().Any()) return;

            var newPublicTech = new Technology()
                                {
                                    TechnologyInternalId = "This is GUID of some public tech This is GUID of some public tech",
                                    ShortDescription = "This is a short description of some public tech",
                                    FullDescription = "This is a long description of some public tech",
                                    CreatedOn = DateTime.Now,
                                    IsCompleted = false
                                };

            var newConfidentialTech = new Technology()
                                      {
                                          TechnologyInternalId = "This is GUID of some confidential tech This is GUID of some public tech",
                                          ShortDescription = "This is a short description of some confidential tech",
                                          FullDescription = "This is a long description of some confidential tech",
                                          CreatedOn = DateTime.Now,
                                          IsCompleted = false
                                      };

            var newSecretTech = new Technology()
                                {
                                    TechnologyInternalId = "This is GUID of some secret tech This is GUID of some public tech",
                                    ShortDescription = "This is a short description of some secret tech",
                                    FullDescription = "This is a long description of some secret tech",
                                    CreatedOn = DateTime.Now,
                                    IsCompleted = false
                                };

            var newTopSecretTech = new Technology()
                                   {
                                       TechnologyInternalId = "This is GUID of some TopSecret tech This is GUID of some public tech",
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
            if (!WebSecurity.UserExists("admin")) { WebSecurity.CreateUserAndAccount("admin", "admin6", new { FirstName = "Admin", LastName = "Admin", Email = "admin@admin.ad"}); }
            if (!WebSecurity.UserExists("userTest1")) { WebSecurity.CreateUserAndAccount("userTest1", "qwerty", new { FirstName = "test1", LastName = "testos1", Email = "test1@test.ts"}); }
            if (!WebSecurity.UserExists("userTest2")) { WebSecurity.CreateUserAndAccount("userTest2", "qwerty", new { FirstName = "test2", LastName = "testos2", Email = "test2@test.ts"}); }
            if (!WebSecurity.UserExists("userTest3")) { WebSecurity.CreateUserAndAccount("userTest3", "qwerty", new { FirstName = "test3", LastName = "testos3", Email = "test3@test.ts" });}
            if (!WebSecurity.UserExists("userTest4")) { WebSecurity.CreateUserAndAccount("userTest4", "qwerty", new { FirstName = "test4", LastName = "testos4", Email = "test4@test.ts" }); }
            if (!WebSecurity.UserExists("userTest5")) { WebSecurity.CreateUserAndAccount("userTest5", "qwerty", new { FirstName = "test5", LastName = "testos5", Email = "test5@test.ts" }); }
        }

        private void AddClerences(CorporationHrDbContext context)
        {
            var listOfClearencesInDb = context.Clearences.Where(x => x.ClearenceId > 0).ToList(); //Don't ask
            if (listOfClearencesInDb.Any()) { return; }

            var clearenceWhite = new ClearenceModel { ClearenceWeight = 0, ClearenceName = "Public", ClearenceRgbColor = "#FFFFFF"};
            var clearenceGreen = new ClearenceModel { ClearenceWeight = 1, ClearenceName = "Normal", ClearenceRgbColor = "#00C957" };
            var clearenceOrange = new ClearenceModel { ClearenceWeight = 2, ClearenceName = "Confidential", ClearenceRgbColor = "#00BFFF" };
            var clearenceRed = new ClearenceModel { ClearenceWeight = 3, ClearenceName = "Secret", ClearenceRgbColor = "#EEC900" };
            var clearenceBlack = new ClearenceModel { ClearenceWeight = 4, ClearenceName = "Top Secret", ClearenceRgbColor = "#CD0000" };

            context.Clearences.Add(clearenceWhite);
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
                user.ClearenceModel = !user.UserName.Equals("admin") ? clearences.Single(x => x.ClearenceName.Equals("Normal")) : clearences.Single(x => x.ClearenceName.Equals("Public"));
                if (user.UserName.Equals("userTest3")) { user.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Confidential")); }
                if (user.UserName.Equals("userTest4")) { user.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Secret")); }
                if (user.UserName.Equals("userTest5")) { user.ClearenceModel = clearences.Single(x => x.ClearenceName.Equals("Top Secret")); }
                context.SaveChanges();
            }
        }
    }
}