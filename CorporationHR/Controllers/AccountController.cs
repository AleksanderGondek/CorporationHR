﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CorporationHR.Context;
using CorporationHR.Repositories;
using WebMatrix.WebData;
using CorporationHR.Models;
using CorporationHR.Helpers;

namespace CorporationHR.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SimpleUserRepository _simpleUserRepo;

        public AccountController(ICorporationHrDatabaseContext databaseContext)
        {
            _simpleUserRepo = new SimpleUserRepository(databaseContext);
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToAction("Index", "Technology");
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email });
                    Roles.AddUserToRole(model.UserName, "Disabled");
                    return RedirectToAction("Registered");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", GeneralHelper.ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Registered

        [Authorize(Roles = "Disabled")]
        public ActionResult Registered()
        {
            return View();
        }

        //
        // GET: /Account/Manage

        [Authorize(Roles = "Active")]
        public ActionResult Manage(GeneralHelper.ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == GeneralHelper.ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == GeneralHelper.ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : "";
            ViewBag.ReturnUrl = Url.Action("Manage");
            ViewBag.UserClearenceName = _simpleUserRepo.GetClearenceNameFromUserName(User.Identity.Name);
            ViewBag.UserClearenceRgbColor = _simpleUserRepo.GetClearenceColorFromUserName(User.Identity.Name);
            ViewBag.UserClearence = _simpleUserRepo.GetCurrentUserClearence(User.Identity.Name);
            return View();
        }

        [Authorize(Roles = "Active")]
        public ActionResult RequestClearence()
        {
            ViewBag.UserClearenceName = _simpleUserRepo.GetClearenceNameFromUserName(User.Identity.Name);
            ViewBag.UserClearenceRgbColor = _simpleUserRepo.GetClearenceColorFromUserName(User.Identity.Name);
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Active")]
        public ActionResult Manage(UserPasswordModel model)
        {
            ViewBag.UserClearenceName = _simpleUserRepo.GetClearenceNameFromUserName(User.Identity.Name);
            ViewBag.UserClearenceRgbColor = _simpleUserRepo.GetClearenceColorFromUserName(User.Identity.Name);
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }
                if (changePasswordSucceeded)
                {
                    return RedirectToAction("Manage", new { Message = GeneralHelper.ManageMessageId.ChangePasswordSuccess });
                }
                
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
