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
    public class SecurityOfTablesController : Controller
    {
        private readonly SecurityOfTablesRepository _securityOfTablesRepo;

        public SecurityOfTablesController(ICorporationHrDatabaseContext databaseContext)
        {
            _securityOfTablesRepo = new SecurityOfTablesRepository(databaseContext);
        }

        // GET: /SecurityOfTables/
        public ActionResult Index()
        {
            return View(_securityOfTablesRepo.All);
        }

        // GET: /SecurityOfTables/Details/5
        public ActionResult Details(int id = 0)
        {
            SecurityOfTable securityoftable = _securityOfTablesRepo.Find(id);
            if (securityoftable == null)
            {
                return HttpNotFound();
            }
            return View(securityoftable);
        }

        // GET: /SecurityOfTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SecurityOfTables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SecurityOfTable securityoftable)
        {
            if (ModelState.IsValid)
            {
                _securityOfTablesRepo.Save(securityoftable);
                return RedirectToAction("Index");
            }

            return View(securityoftable);
        }

        // GET: /SecurityOfTables/Edit/5
        public ActionResult Edit(int id = 0)
        {
            SecurityOfTable securityoftable = _securityOfTablesRepo.Find(id);
            if (securityoftable == null)
            {
                return HttpNotFound();
            }
            return View(securityoftable);
        }

        // POST: /SecurityOfTables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SecurityOfTable securityoftable)
        {
            if (ModelState.IsValid)
            {
                _securityOfTablesRepo.Update(securityoftable);
                return RedirectToAction("Index");
            }
            return View(securityoftable);
        }

        // GET: /SecurityOfTables/Delete/5
        public ActionResult Delete(int id = 0)
        {
            SecurityOfTable securityoftable = _securityOfTablesRepo.Find(id);
            if (securityoftable == null)
            {
                return HttpNotFound();
            }
            return View(securityoftable);
        }

        // POST: /SecurityOfTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecurityOfTable securityoftable = _securityOfTablesRepo.Find(id);
            _securityOfTablesRepo.Remove(securityoftable);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _securityOfTablesRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}