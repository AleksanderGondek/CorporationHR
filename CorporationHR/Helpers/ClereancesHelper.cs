using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using CorporationHR.Context;
using Ninject;
using Ninject.Modules;

namespace CorporationHR.Helpers
{
    public class ClereancesHelper
    {
        public ClereancesHelper(ICorporationHrDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
        
        private static ClereancesHelper _instance;
        protected ICorporationHrDatabaseContext DatabaseContext;

        public static ClereancesHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    var kernel = new StandardKernel();
                    kernel.Load(Assembly.GetExecutingAssembly());
                    kernel.Bind<ICorporationHrDatabaseContext>().To<CorporationHrDbContext>();
                    _instance = new ClereancesHelper(kernel.Get<ICorporationHrDatabaseContext>());
                }
                return  _instance;
            }
            set { _instance = value; }
        }

        public void RemoveContext()
        {
            this.DatabaseContext.Dispose();
            this.DatabaseContext = null;
        }

        public void ReloadContext()
        {
            if (this.DatabaseContext != null)
            {
                DatabaseContext.Dispose();
                DatabaseContext = null;
            }

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<ICorporationHrDatabaseContext>().To<CorporationHrDbContext>();
            DatabaseContext = kernel.Get<ICorporationHrDatabaseContext>();
        }

        public string GetClearenceNameFromUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return "We coudn't aquire your clerance :(";
            var user = DatabaseContext.UserProfiles.Single(x => x.UserName.Equals(userName));
            return user != null ? user.ClearenceModel.ClearenceName : "We coudn't aquire your clerance :(";
        }

        public string GetClearenceColorFromUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return "#FFFFFF";
            var user = DatabaseContext.UserProfiles.Single(x => x.UserName.Equals(userName));
            return user != null ? user.ClearenceModel.ClearenceRgbColor : "#FFFFFF";
        }
        public int GetClearenceWeightFromUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return -1;
            var user = DatabaseContext.UserProfiles.Single(x => x.UserName.Equals(userName));
            return user != null ? user.ClearenceModel.ClearenceWeight : -1;
        }

        public bool CheckIfUserCanViewContent(string userName, string controllerName)
        {
            var userCleranceWeight = GetClearenceWeightFromUserName(userName);
            var controllerClereanceWeight = GetClearenceWeightFromControllerName(controllerName);

            if (controllerClereanceWeight == -1) return false;
            return userCleranceWeight >= controllerClereanceWeight; //No read up
        }

        public bool CheckIfUserCanWriteContent(string userName, string controllerName)
        {
            var userCleranceWeight = GetClearenceWeightFromUserName(userName);
            var controllerClereanceWeight = GetClearenceWeightFromControllerName(controllerName);

            if (controllerClereanceWeight == -1) return false;
            return controllerClereanceWeight >= userCleranceWeight; //No read up
        }

        public bool CheckIfUserCanEditAndDeleteContent(string userName, string controllerName)
        {
            var userCleranceWeight = GetClearenceWeightFromUserName(userName);
            var controllerClereanceWeight = GetClearenceWeightFromControllerName(controllerName);

            if (controllerClereanceWeight == -1) return false;
            return controllerClereanceWeight == userCleranceWeight; 
        }

        public int GetClearenceWeightFromControllerName(string controllerName)
        {
            if (string.IsNullOrEmpty(controllerName)) return -1;
            var securityTableEntry = DatabaseContext.SecurityOfTables.Single(x => x.TableName.Equals(controllerName));
            return securityTableEntry != null ? securityTableEntry.ClearenceModel.ClearenceWeight : -1;
        }

        public string GetClearenceNameFromControllerName(string controllerName)
        {
            if (string.IsNullOrEmpty(controllerName)) return "We coudn't aquire clerance :(";
            var user = DatabaseContext.SecurityOfTables.Single(x => x.TableName.Equals(controllerName));
            return user != null ? user.ClearenceModel.ClearenceName : "We coudn't aquire clerance :(";
        }

        public string GetClearenceColorFromControllerName(string controllerName)
        {
            if (string.IsNullOrEmpty(controllerName)) return "#FFFFFF";
            var user = DatabaseContext.SecurityOfTables.Single(x => x.TableName.Equals(controllerName));
            return user != null ? user.ClearenceModel.ClearenceRgbColor : "#FFFFFF";
        }

        public IEnumerable<SelectListItem> GetClearencesSelectList()
        {
            if (!DatabaseContext.Clearences.Any()) return null;
            var values = DatabaseContext.Clearences.ToList().Select(x => new SelectListItem() { Value = x.ClearenceId.ToString(), Text = string.Format("{0} - {1}",x.ClearenceName, x.ClearenceWeight.ToString()) });
            return new SelectList(values, "Value", "Text");
        }
    }
}