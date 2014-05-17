using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CorporationHR.CustomAttribute;
using CorporationHR.Models;
using CorporationHR.Context;
using CorporationHR.Repositories;

namespace CorporationHR.Controllers
{
    [RequireHttps]
    [Authorize]
    public class ClereancesController : Controller
    {
        private readonly ClearencesRepository _clearencesRepo;

        public ClereancesController(ICorporationHrDatabaseContext databaseContext)
        {
            _clearencesRepo = new ClearencesRepository(databaseContext);
        }

        // GET: /Clereances/
        [CustomAuthorizeRead(CallingController = "Clearence Models")]
        public ActionResult Index()
        {
            return View(_clearencesRepo.All);
        }

        // GET: /Clereances/Details/5
        [CustomAuthorizeRead(CallingController = "Clearence Models")]
        public ActionResult Details(int id = 0)
        {
            ClearenceModel clearencemodel = _clearencesRepo.Find(id);
            if (clearencemodel == null)
            {
                return HttpNotFound();
            }
            return View(clearencemodel);
        }

        // GET: /Clereances/Create
        [CustomAuthorizeWrite(CallingController = "Clearence Models")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Clereances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeEditDel(CallingController = "Clearence Models")]
        public ActionResult Create(ClearenceModel clearencemodel)
        {
            if (ModelState.IsValid)
            {
                _clearencesRepo.Save(clearencemodel);
                return RedirectToAction("Index");
            }

            return View(clearencemodel);
        }

        // GET: /Clereances/Edit/5
        [CustomAuthorizeEditDel(CallingController = "Clearence Models")]
        public ActionResult Edit(int id = 0)
        {
            ClearenceModel clearencemodel = _clearencesRepo.Find(id);
            if (clearencemodel == null)
            {
                return HttpNotFound();
            }
            return View(clearencemodel);
        }

        // POST: /Clereances/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeEditDel(CallingController = "Clearence Models")]
        public ActionResult Edit(ClearenceModel clearencemodel)
        {
            if (ModelState.IsValid)
            {
                _clearencesRepo.Update(clearencemodel);
                return RedirectToAction("Index");
            }
            return View(clearencemodel);
        }

        // GET: /Clereances/Delete/5
        [CustomAuthorizeEditDel(CallingController = "Clearence Models")]
        public ActionResult Delete(int id = 0)
        {
            ClearenceModel clearencemodel = _clearencesRepo.Find(id);
            if (clearencemodel == null)
            {
                return HttpNotFound();
            }
            return View(clearencemodel);
        }

        // POST: /Clereances/Delete/5
        [CustomAuthorizeEditDel(CallingController = "Clearence Models")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClearenceModel clearencemodel = _clearencesRepo.Find(id);
            _clearencesRepo.Remove(clearencemodel);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _clearencesRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}