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
    public class PatentsController : Controller
    {
        private readonly PatentsRepository _patentsRepo;

        public PatentsController(ICorporationHrDatabaseContext databaseContext)
        {
            _patentsRepo = new PatentsRepository(databaseContext);
        }

        // GET: /Patents/
        [CustomAuthorizeRead(CallingController = "Patents")]
        public ActionResult Index()
        {
            return View(_patentsRepo.All);
        }

        // GET: /Patents/Details/5
        [CustomAuthorizeRead(CallingController = "Patents")]
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
        [CustomAuthorizeWrite(CallingController = "Patents")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Patents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeWrite(CallingController = "Patents")]
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
        [CustomAuthorizeEditDel(CallingController = "Patents")]
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
        [CustomAuthorizeEditDel(CallingController = "Patents")]
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
        [CustomAuthorizeEditDel(CallingController = "Patents")]
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
        [CustomAuthorizeEditDel(CallingController = "Patents")]
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