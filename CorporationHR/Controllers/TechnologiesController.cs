using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorporationHR.CustomAttribute;
using CorporationHR.Models;
using CorporationHR.Repositories;

namespace CorporationHR.Context
{
    public class TechnologiesController : Controller
    {
        private readonly TechnologiesRepository _technologiesRepo;

        public TechnologiesController(ICorporationHrDatabaseContext databaseContext)
        {
            _technologiesRepo = new TechnologiesRepository(databaseContext);
        }

        // GET: /Technologies/
        [CustomAuthorizeRead(CallingController = "Technologies")]
        public ActionResult Index()
        {
            return View(_technologiesRepo.All);
        }

        // GET: /Technologies/Details/5
        [CustomAuthorizeRead(CallingController = "Technologies")]
        public ActionResult Details(int id = 0)
        {
            Technology technology = _technologiesRepo.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        [CustomAuthorizeWrite(CallingController = "Technologies")]
        // GET: /Technologies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Technologies/Create
        [CustomAuthorizeWrite(CallingController = "Technologies")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Technology technology)
        {
            if (ModelState.IsValid)
            {
                _technologiesRepo.Save(technology);
                return RedirectToAction("Index");
            }

            return View(technology);
        }

        // GET: /Technologies/Edit/5
        [CustomAuthorizeWrite(CallingController = "Technologies")]
        public ActionResult Edit(int id = 0)
        {
            Technology technology = _technologiesRepo.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        // POST: /Technologies/Edit/5
        [CustomAuthorizeWrite(CallingController = "Technologies")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Technology technology)
        {
            if (ModelState.IsValid)
            {
                _technologiesRepo.Update(technology);
                return RedirectToAction("Index");
            }
            return View(technology);
        }

        // GET: /Technologies/Delete/5
        [CustomAuthorizeWrite(CallingController = "Technologies")]
        public ActionResult Delete(int id = 0)
        {
            Technology technology = _technologiesRepo.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        // POST: /Technologies/Delete/5
        [CustomAuthorizeWrite(CallingController = "Technologies")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Technology technology = _technologiesRepo.Find(id);
            _technologiesRepo.Remove(technology);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _technologiesRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}