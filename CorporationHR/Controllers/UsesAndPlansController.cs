using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorporationHR.CustomAttribute;
using CorporationHR.Models;
using CorporationHR.Context;
using CorporationHR.Repositories;

namespace CorporationHR.Controllers
{
    [RequireHttps]
    public class UsesAndPlansController : Controller
    {
        private readonly UseAndPlansRepository _usesAndPlansRepo;

        public UsesAndPlansController(ICorporationHrDatabaseContext databaseContext)
        {
            _usesAndPlansRepo = new UseAndPlansRepository(databaseContext);
        }

        // GET: /UsesAndPlans/
        [CustomAuthorizeRead(CallingController = "UsesAndPlans")]
        public ActionResult Index()
        {
            return View(_usesAndPlansRepo.All);
        }

        // GET: /UsesAndPlans/Details/5
        [CustomAuthorizeRead(CallingController = "UsesAndPlans")]
        public ActionResult Details(int id = 0)
        {
            UseAndPlan useandplan = _usesAndPlansRepo.Find(id);
            if (useandplan == null)
            {
                return HttpNotFound();
            }
            return View(useandplan);
        }

        // GET: /UsesAndPlans/Create
        [CustomAuthorizeWrite(CallingController = "UsesAndPlans")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UsesAndPlans/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeWrite(CallingController = "UsesAndPlans")]
        public ActionResult Create(UseAndPlan useandplan)
        {
            if (ModelState.IsValid)
            {
                _usesAndPlansRepo.Save(useandplan);
                return RedirectToAction("Index");
            }

            return View(useandplan);
        }

        // GET: /UsesAndPlans/Edit/5
        [CustomAuthorizeEditDel(CallingController = "UsesAndPlans")]
        public ActionResult Edit(int id = 0)
        {
            UseAndPlan useandplan = _usesAndPlansRepo.Find(id);
            if (useandplan == null)
            {
                return HttpNotFound();
            }
            return View(useandplan);
        }

        // POST: /UsesAndPlans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeEditDel(CallingController = "UsesAndPlans")]
        public ActionResult Edit(UseAndPlan useandplan)
        {
            if (ModelState.IsValid)
            {
                _usesAndPlansRepo.Update(useandplan);
                return RedirectToAction("Index");
            }
            return View(useandplan);
        }

        // GET: /UsesAndPlans/Delete/5
        [CustomAuthorizeEditDel(CallingController = "UsesAndPlans")]
        public ActionResult Delete(int id = 0)
        {
            UseAndPlan useandplan = _usesAndPlansRepo.Find(id);
            if (useandplan == null)
            {
                return HttpNotFound();
            }
            return View(useandplan);
        }

        // POST: /UsesAndPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeEditDel(CallingController = "UsesAndPlans")]
        public ActionResult DeleteConfirmed(int id)
        {
            UseAndPlan useandplan = _usesAndPlansRepo.Find(id);
            _usesAndPlansRepo.Remove(useandplan);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _usesAndPlansRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}