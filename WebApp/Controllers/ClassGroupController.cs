using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using WebApp.Business.BusinessBL;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ClassGroupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ClassGroupBL logic = new ClassGroupBL();
        // GET: ClassGroup
        public ActionResult Index()
        {
            //var classGroupViewModels = db.ClassGroupViewModels.Include(c => c.Grades);
            return View(logic.GetAllClassGroup());
        }

        // GET: ClassGroup/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClassGroupViewModels classGroupViewModels = db.ClassGroupViewModels.Find(id);
        //    if (classGroupViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(classGroupViewModels);
        //}

        // GET: ClassGroup/Create
        public ActionResult Create()
        {
            ViewBag.Grade_id = new SelectList(db.Grades, "Grade_id", "GradeName");
            return View();
        }

        // POST: ClassGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassGroupe_id,GroupeName,Grade_id")] ClassGroupViewModels classGroupViewModels)
        {
            if (ModelState.IsValid)
            {

                logic.AddClassGroup(classGroupViewModels);
                return RedirectToAction("Index");
            }

            ViewBag.Grade_id = new SelectList(db.Grades, "Grade_id", "GradeName", classGroupViewModels.Grade_id);
            return View(classGroupViewModels);
        }

        // GET: ClassGroup/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClassGroupViewModels classGroupViewModels = db.ClassGroupViewModels.Find(id);
        //    if (classGroupViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Grade_id = new SelectList(db.Grades, "Grade_id", "GradeName", classGroupViewModels.Grade_id);
        //    return View(classGroupViewModels);
        //}

        // POST: ClassGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ClassGroupe_id,GroupeName,Grade_id")] ClassGroupViewModels classGroupViewModels)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(classGroupViewModels).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Grade_id = new SelectList(db.Grades, "Grade_id", "GradeName", classGroupViewModels.Grade_id);
        //    return View(classGroupViewModels);
        //}

        //// GET: ClassGroup/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClassGroupViewModels classGroupViewModels = db.ClassGroupViewModels.Find(id);
        //    if (classGroupViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(classGroupViewModels);
        //}

        // POST: ClassGroup/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    ClassGroupViewModels classGroupViewModels = db.ClassGroupViewModels.Find(id);
        //    db.ClassGroupViewModels.Remove(classGroupViewModels);
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
