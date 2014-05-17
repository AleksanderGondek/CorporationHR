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
    [RequireHttps]
    public class PatentsController : Controller
    {
        private readonly PatentsRepository _patentsRepo;

        public PatentsController(ICorporationHrDatabaseContext databaseContext)
        {
            _patentsRepo = new PatentsRepository(databaseContext);
        }

        // GET: /Patents/
        public ActionResult Index()
        {
            return View(_patentsRepo.All);
        }

        // GET: /Patents/Details/5
        public ActionResult Details(int id = 0)
        {
            Patent patent = _patentsRepo.Find(id);
            if (patent == null)
            {
                return HttpNotFound();
            }
            return View(patent);
        }

        // GET: /Patents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Patents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patent patent)
        {
            if (ModelState.IsValid)
            {
                _patentsRepo.Save(patent);
                return RedirectToAction("Index");
            }

            return View(patent);
        }

        // GET: /Patents/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Patent patent = _patentsRepo.Find(id);
            if (patent == null)
            {
                return HttpNotFound();
            }
            return View(patent);
        }
        
        // POST: /Patents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patent patent)
        {
            if (ModelState.IsValid)
            {
                _patentsRepo.Update(patent);
                return RedirectToAction("Index");
            }
            return View(patent);
        }

        // GET: /Patents/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Patent patent = _patentsRepo.Find(id);
            if (patent == null)
            {
                return HttpNotFound();
            }
            return View(patent);
        }

        // POST: /Patents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patent patent = _patentsRepo.Find(id);
            _patentsRepo.Remove(patent);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _patentsRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}