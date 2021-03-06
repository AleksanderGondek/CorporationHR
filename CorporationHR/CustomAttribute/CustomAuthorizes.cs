﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CorporationHR.Helpers;

namespace CorporationHR.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeRead : System.Web.Mvc.AuthorizeAttribute
    {
        public string CallingController { get; set; }
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(CallingController) && !string.IsNullOrEmpty(filterContext.HttpContext.User.Identity.Name))
                {
                    if (ClereancesHelper.Instance.CheckIfUserCanWriteContent(filterContext.HttpContext.User.Identity.Name, CallingController))
                    {
                        filterContext.Result = filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "ExploreDb" })); 
                    }
                    else
                    {
                        filterContext.Result = filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Forbidden" })); 
                    }
                }
                else
                {
                    filterContext.Result = filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Forbidden" })); 
                }
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) return base.AuthorizeCore(httpContext);
            if (!string.IsNullOrEmpty(CallingController) && !string.IsNullOrEmpty(httpContext.User.Identity.Name)) return ClereancesHelper.Instance.CheckIfUserCanViewContent(httpContext.User.Identity.Name, CallingController);
            return base.AuthorizeCore(httpContext);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeWrite : System.Web.Mvc.AuthorizeAttribute
    {
        public string CallingController { get; set; }
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Forbidden" }));
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) return base.AuthorizeCore(httpContext);
            if (!string.IsNullOrEmpty(CallingController) && !string.IsNullOrEmpty(httpContext.User.Identity.Name)) return ClereancesHelper.Instance.CheckIfUserCanWriteContent(httpContext.User.Identity.Name, CallingController);
            return base.AuthorizeCore(httpContext);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeEditDel : System.Web.Mvc.AuthorizeAttribute
    {
        public string CallingController { get; set; }
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Forbidden" }));
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) return base.AuthorizeCore(httpContext);
            if (!string.IsNullOrEmpty(CallingController) && !string.IsNullOrEmpty(httpContext.User.Identity.Name)) return ClereancesHelper.Instance.CheckIfUserCanEditAndDeleteContent(httpContext.User.Identity.Name, CallingController);
            return base.AuthorizeCore(httpContext);
        }
    }
}