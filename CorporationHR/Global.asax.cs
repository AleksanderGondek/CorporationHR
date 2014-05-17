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
            db.Database.Initialize(false);
            db.UserProfiles.Find(1);
            db.Clearences.Find(1);

        }
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<ICorporationHrDatabaseContext>().To<CorporationHrDbContext>();
            return kernel;
        }

        protected void Application_BeginRequest()
        {
            if (!Context.Request.IsSecureConnection)
            {
                var urlToHttps = Context.Request.Url.ToString().Replace("http:", "https:");
                Response.Redirect(urlToHttps.Replace("57420", "44300"));               
            }

        }
    }
}