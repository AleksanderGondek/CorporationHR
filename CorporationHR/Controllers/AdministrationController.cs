using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CorporationHR.Context;
using CorporationHR.Helpers;
using CorporationHR.Models;
using CorporationHR.Repositories;
using WebMatrix.WebData;

namespace CorporationHR.Controllers
{
    [Authorize(Users="admin")]
    public class AdministrationController : Controller
    {
        private SystemUsersRepository _systemUsersRepo;

        public AdministrationController(ICorporationHrDatabaseContext databaseContext)
        {
            _systemUsersRepo = new SystemUsersRepository(databaseContext);
        }

        //
        // GET: /Administration/

        public ActionResult ManageUsers()
        {
            return View(_systemUsersRepo.All());
        }

        //
        // GET: /Administration/Details/5

        public ActionResult UserDetails(int id)
        {
            return View(new AdminUserProfileModel(_systemUsersRepo.Find(id)));
        }

        //
        // GET: /Administration/Create

        public ActionResult CreateUser()
        {
            return View();
        }

        //
        // POST: /Administration/Create

        [HttpPost]
        public ActionResult CreateUser(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email });
                    Roles.AddUserToRole(model.UserName, "Disabled");
                    return RedirectToAction("ManageUsers");
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
        // GET: /Administration/Edit/5

        public ActionResult EditUser(int id)
        {
            return View(new AdminUserProfileModel(_systemUsersRepo.Find(id)));
        }

        //
        // POST: /Administration/Edit/5

        [HttpPost]
        public ActionResult EditUser(AdminUserProfileModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _systemUsersRepo.AdminUpdate(userModel);
                }
                return RedirectToAction("ManageUsers");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administration/Delete/5

        public ActionResult DeleteUser(int id)
        {
            return View(new AdminUserProfileModel(_systemUsersRepo.Find(id)));
        }

        //
        // POST: /Administration/Delete/5

        [HttpPost]
        public ActionResult DeleteUser(AdminUserProfileModel userModel)
        {
            try
            {
                _systemUsersRepo.Remove(userModel.UserId);
                return RedirectToAction("ManageUsers");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administration/DisableUser/5
        public ActionResult ChangeUserStatus(string userName, bool enabled)
        {
            var userStatus = enabled ? "Active" : "Disabled";
            var currentUserStatus = Roles.GetRolesForUser(userName);

            Roles.RemoveUserFromRoles(userName, currentUserStatus);
            Roles.AddUserToRole(userName, userStatus);

            return RedirectToAction("ManageUsers");
        }
    }
}
