using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CorporationHR.Context;
using CorporationHR.Models;
using Ninject;
using Ninject.Web.Common;

namespace CorporationHR
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DbInitialization, with magic concering SimpleAuth
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CorporationHrDbContext, DatabaseInitializator>());

            //Filling up with Clearances
            var db = new CorporationHrDbContext();
            if (!db.Clearences.Any(x => x.ClearenceName.Equals("Public")))
            {
                var clearenceGreen = new ClearenceModel { ClearenceName = "Public" };
                var clearenceOrange = new ClearenceModel { ClearenceName ="Confidential" };
                var clearenceRed = new ClearenceModel { ClearenceName = "Secret" };
                var clearenceBlack = new ClearenceModel { ClearenceName = "Top Secret" };

                db.Clearences.Add(clearenceGreen);
                db.Clearences.Add(clearenceOrange);
                db.Clearences.Add(clearenceRed);
                db.Clearences.Add(clearenceBlack);
                db.SaveChanges();
            }

        }
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<ICorporationHrDatabaseContext>().To<CorporationHrDbContext>();
            return kernel;
        }
    }
}