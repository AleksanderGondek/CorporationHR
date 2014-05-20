using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CorporationHR.CustomAttribute;
using CorporationHR.Helpers;
using CorporationHR.Models;
using CorporationHR.Context;
using CorporationHR.Repositories;
using WebMatrix.WebData;

namespace CorporationHR.Controllers
{
    [RequireHttps]
    [Authorize]
    public class UserProfilesController : Controller
    {
        private readonly UserProfilesRepository _userProfilesRepo;

        public UserProfilesController(ICorporationHrDatabaseContext databaseContext)
        {
            _userProfilesRepo = new UserProfilesRepository(databaseContext);
        }

        // GET: /UserProfiles/
        [CustomAuthorizeRead(CallingController = "User Profiles")]
        public ActionResult Index()
        {
            return View(_userProfilesRepo.All);
        }

        // GET: /UserProfiles/Details/5
        [CustomAuthorizeRead(CallingController = "User Profiles")]
        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = _userProfilesRepo.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        // GET: /UserProfiles/Create
        [CustomAuthorizeWrite(CallingController = "User Profiles")]
        public ActionResult Create()
        {
            var newUser = new RegisterModel
            {
                SelectedClearenceId = -1,
                Clearences = ClereancesHelper.Instance.GetClearencesSelectList()
            };
            return View(newUser);
        }

        // POST: /UserProfiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeWrite(CallingController = "User Profiles")]
        public ActionResult Create(RegisterModel userprofile)
        {
            if (ModelState.IsValid)
            {
                _userProfilesRepo.Save(userprofile);

                return RedirectToAction("Index");
            }

            return View(userprofile);
        }

        // GET: /UserProfiles/Edit/5
        [CustomAuthorizeEditDel(CallingController = "User Profiles")]
        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = _userProfilesRepo.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }

            userprofile.SelectedClearenceId = userprofile.ClearenceModel != null
                ? userprofile.ClearenceModel.ClearenceId
                : -1;
            userprofile.Clearences = ClereancesHelper.Instance.GetClearencesSelectList();

            return View(userprofile);
        }

        // POST: /UserProfiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeEditDel(CallingController = "User Profiles")]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                _userProfilesRepo.Update(userprofile);
                return RedirectToAction("Index");
            }
            return View(userprofile);
        }

        // GET: /UserProfiles/Delete/5
        [CustomAuthorizeEditDel(CallingController = "User Profiles")]
        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = _userProfilesRepo.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        // POST: /UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeEditDel(CallingController = "User Profiles")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = _userProfilesRepo.Find(id);
            if (userprofile.UserName.Equals(User.Identity.Name))
            {
                _userProfilesRepo.Remove(userprofile);
                WebSecurity.Logout();
                return RedirectToAction("Index", "Home");   
            }
            
            _userProfilesRepo.Remove(userprofile);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _userProfilesRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}