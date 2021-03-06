﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorporationHR.Controllers
{
    [RequireHttps]
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult Forbidden()
        {
            return View();
        }

        public ActionResult CustomError(string errorTitle, string errorText)
        {
            ViewBag.ErrorTitle = errorTitle;
            ViewBag.ErrorText = errorText;
            return View();
        }
    }
}
