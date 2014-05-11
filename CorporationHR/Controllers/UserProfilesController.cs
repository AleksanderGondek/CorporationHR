using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorporationHR.Models;
using CorporationHR.Context;
using CorporationHR.Repositories;

namespace CorporationHR.Controllers
{
    [Authorize]
    public class UserProfilesController : Controller
    {
        private readonly UserProfilesRepository _userProfilesRepo;

        public UserProfilesController(ICorporationHrDatabaseContext databaseContext)
        {
            _userProfilesRepo = new UserProfilesRepository(databaseContext);
        }

        // GET: /UserProfiles/
        public ActionResult Index()
        {
            return View(_userProfilesRepo.All);
        }

        // GET: /UserProfiles/Details/5
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserProfiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                _userProfilesRepo.Save(userprofile);
                return RedirectToAction("Index");
            }

            return View(userprofile);
        }

        // GET: /UserProfiles/Edit/5
        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = _userProfilesRepo.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        // POST: /UserProfiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = _userProfilesRepo.Find(id);
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