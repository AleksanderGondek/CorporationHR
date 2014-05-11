using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorporationHR.Models;
using CorporationHR.Repositories;

namespace CorporationHR.Context
{
    [Authorize(Roles = "Active")]
    public class TechnologyController : Controller
    {
        private TechnologyRepository _technologyRepo;

        public TechnologyController(ICorporationHrDatabaseContext databaseContext)
        {
            _technologyRepo = new TechnologyRepository(databaseContext);
        }
        //
        // GET: /Technology/

        public ActionResult Index()
        {
            ViewBag.UserClearenceName = _technologyRepo.GetClearenceNameFromUserName(User.Identity.Name);
            ViewBag.UserClearenceRgbColor = _technologyRepo.GetClearenceColorFromUserName(User.Identity.Name);
            ViewBag.UserClearenceWeight = _technologyRepo.GetCurrentUserClearenceWeight(User.Identity.Name);
            ViewBag.ClearencesIdToColorMapping = _technologyRepo.GetClearencesColors();
            return View(_technologyRepo.All);
        }

        //
        // GET: /Technology/Details/5

        public ActionResult Details(int id = 0)
        {
            ViewBag.UserClearenceName = _technologyRepo.GetClearenceNameFromUserName(User.Identity.Name);
            ViewBag.UserClearenceRgbColor = _technologyRepo.GetClearenceColorFromUserName(User.Identity.Name);
            Technology technology = _technologyRepo.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        //
        // GET: /Technology/Create

        public ActionResult Create()
        {
            ViewBag.UserClearenceName = _technologyRepo.GetClearenceNameFromUserName(User.Identity.Name);
            ViewBag.UserClearenceRgbColor = _technologyRepo.GetClearenceColorFromUserName(User.Identity.Name);
            return View(new TechnologyCreationModel());
        }

        //
        // POST: /Technology/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TechnologyCreationModel technology)
        {
            if (ModelState.IsValid)
            {
                var techno = new Technology();
                techno.TechnologyInternalId = technology.TechnologyInternalId;
                techno.ShortDescription = technology.ShortDescription;
                techno.FullDescription = technology.FullDescription;
                techno.CreatedOn = technology.CreatedOn;
                techno.IsCompleted = technology.IsCompleted;

                _technologyRepo.Save(techno);
                return RedirectToAction("Index");
            }

            return View(technology);
        }

        //
        // GET: /Technology/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.UserClearenceName = _technologyRepo.GetClearenceNameFromUserName(User.Identity.Name);
            ViewBag.UserClearenceRgbColor = _technologyRepo.GetClearenceColorFromUserName(User.Identity.Name);

            Technology technology = _technologyRepo.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        //
        // POST: /Technology/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Technology technology)
        {
            if (ModelState.IsValid)
            {
                _technologyRepo.Update(technology);
                return RedirectToAction("Index");
            }
            return View(technology);
        }

        //
        // GET: /Technology/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ViewBag.UserClearenceName = _technologyRepo.GetClearenceNameFromUserName(User.Identity.Name);
            ViewBag.UserClearenceRgbColor = _technologyRepo.GetClearenceColorFromUserName(User.Identity.Name);

            Technology technology = _technologyRepo.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        //
        // POST: /Technology/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Technology technology = _technologyRepo.Find(id);
            _technologyRepo.Remove(technology);
            return RedirectToAction("Index");
        }
    }
}