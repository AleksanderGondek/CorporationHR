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
    public class TechnologyAuthorsController : Controller
    {
        private readonly TechnologyAuthorsRepository _technologyAuthorsRepo;

        public TechnologyAuthorsController(ICorporationHrDatabaseContext databaseContext)
        {
            _technologyAuthorsRepo = new TechnologyAuthorsRepository(databaseContext);
        }

        // GET: /TechnologyAuthors/
        [CustomAuthorizeRead(CallingController = "TechnologyAuthors")]
        public ActionResult Index()
        {
            return View(_technologyAuthorsRepo.All);
        }

        // GET: /TechnologyAuthors/Details/5
        [CustomAuthorizeRead(CallingController = "TechnologyAuthors")]
        public ActionResult Details(int id = 0)
        {
            TechnologyAuthor technologyauthor = _technologyAuthorsRepo.Find(id);
            if (technologyauthor == null)
            {
                return HttpNotFound();
            }
            return View(technologyauthor);
        }

        // GET: /TechnologyAuthors/Create
        [CustomAuthorizeWrite(CallingController = "TechnologyAuthors")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TechnologyAuthors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeWrite(CallingController = "TechnologyAuthors")]
        public ActionResult Create(TechnologyAuthor technologyauthor)
        {
            if (ModelState.IsValid)
            {
                _technologyAuthorsRepo.Save(technologyauthor);
                return RedirectToAction("Index");
            }

            return View(technologyauthor);
        }

        // GET: /TechnologyAuthors/Edit/5
        [CustomAuthorizeEditDel(CallingController = "TechnologyAuthors")]
        public ActionResult Edit(int id = 0)
        {
            TechnologyAuthor technologyauthor = _technologyAuthorsRepo.Find(id);
            if (technologyauthor == null)
            {
                return HttpNotFound();
            }
            return View(technologyauthor);
        }


        // POST: /TechnologyAuthors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeEditDel(CallingController = "TechnologyAuthors")]
        public ActionResult Edit(TechnologyAuthor technologyauthor)
        {
            if (ModelState.IsValid)
            {
                _technologyAuthorsRepo.Update(technologyauthor);
                return RedirectToAction("Index");
            }
            return View(technologyauthor);
        }


        // GET: /TechnologyAuthors/Delete/5
        [CustomAuthorizeEditDel(CallingController = "TechnologyAuthors")]
        public ActionResult Delete(int id = 0)
        {
            TechnologyAuthor technologyauthor = _technologyAuthorsRepo.Find(id);
            if (technologyauthor == null)
            {
                return HttpNotFound();
            }
            return View(technologyauthor);
        }

        // POST: /TechnologyAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorizeEditDel(CallingController = "TechnologyAuthors")]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnologyAuthor technologyauthor = _technologyAuthorsRepo.Find(id);
            _technologyAuthorsRepo.Remove(technologyauthor);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _technologyAuthorsRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}