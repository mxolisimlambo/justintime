using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Business.IBusinessBl;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SubjectsViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SubjectBL subjectbl = new SubjectBL();

        public SubjectsViewModelsController() { }
        public SubjectsViewModelsController(SubjectBL subjectbl)
        {
            this.subjectbl = subjectbl;
        }

        // GET: SubjectsViewModels
        public ActionResult Index()
        {
           
            return View(subjectbl.GetAllSubject());
        }

        // GET: SubjectsViewModels/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SubjectsViewModel subjectsViewModel = db.SubjectsViewModels.Find(id);
        //    if (subjectsViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subjectsViewModel);
        //}

        // GET: SubjectsViewModels/Create
        public ActionResult Create()
        {
            ViewBag.Stream_Code = new SelectList(db.StreamTables, "Stream_Code", "Description");
            return View();
        }

        // POST: SubjectsViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Subject_Code,DescriptiveTitle,Stream_Code")] SubjectsViewModel subjectsViewModel)
        {
            if (ModelState.IsValid)
            {
                subjectbl.AddSubject(subjectsViewModel);
              
                return RedirectToAction("Index");
            }

            ViewBag.Stream_Code = new SelectList(db.StreamTables, "Stream_Code", "Description", subjectsViewModel.Stream_Code);
            return View(subjectsViewModel);
        }

        // GET: SubjectsViewModels/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SubjectsViewModel subjectsViewModel = db.SubjectsViewModels.Find(id);
        //    if (subjectsViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Stream_Code = new SelectList(db.StreamTables, "Stream_Code", "Description", subjectsViewModel.Stream_Code);
        //    return View(subjectsViewModel);
        //}

        // POST: SubjectsViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Subject_Code,DescriptiveTitle,Stream_Code")] SubjectsViewModel subjectsViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectsViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Stream_Code = new SelectList(db.StreamTables, "Stream_Code", "Description", subjectsViewModel.Stream_Code);
            return View(subjectsViewModel);
        }

        // GET: SubjectsViewModels/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SubjectsViewModel subjectsViewModel = db.SubjectsViewModels.Find(id);
        //    if (subjectsViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(subjectsViewModel);
        //}

        // POST: SubjectsViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    SubjectsViewModel subjectsViewModel = db.SubjectsViewModels.Find(id);
        //    db.SubjectsViewModels.Remove(subjectsViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
