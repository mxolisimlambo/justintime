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
    public class AssignTeacherToClassController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly AssignTeacherToClassBL _logic = new AssignTeacherToClassBL();
        // GET: AssignTeacherToClass
        public ActionResult Index()
        {
            return View(db.AssignTeacherToClasss.ToList());
        }

        // GET: AssignTeacherToClass/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AssignTeacherToClassViewmodel assignTeacherToClassViewmodel = db.AssignTeacherToClassViewmodels.Find(id);
        //    if (assignTeacherToClassViewmodel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(assignTeacherToClassViewmodel);
        //}

        // GET: AssignTeacherToClass/Create
        public ActionResult Create()
        {
            ViewBag.StaffNumber = new SelectList(db.AssignTeacherToClasss, "StaffNumber", "StaffNumber");
            ViewBag.GradeGroupId = new SelectList(db.AssignTeacherToClasss, "GradeGroupId", "GradeGroupId");
            //ViewBag.SubjectCode = new SelectList(db.Subjects, "SubjectCode", "SubjectCode");
            return View();
        }

        // POST: AssignTeacherToClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StaffNumber,GradeGroupId")] AssignTeacherToClassViewmodel assignTeacherToClassViewmodel)
        {
            if (ModelState.IsValid)
            {
                _logic.AssignTeacherToClass(assignTeacherToClassViewmodel);
                return RedirectToAction("Index");
            }
            ViewBag.StaffNumber = new SelectList(db.AssignTeacherToClasss, "StaffNumber", "StaffNumber", assignTeacherToClassViewmodel.StaffNumber);
            ViewBag.GradeGroupId = new SelectList(db.AssignTeacherToClasss, "GradeGroupId", "GradeGroupId", assignTeacherToClassViewmodel.GradeGroupId);
            return View(assignTeacherToClassViewmodel);
        }

        // GET: AssignTeacherToClass/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AssignTeacherToClassViewmodel assignTeacherToClassViewmodel = db.AssignTeacherToClassViewmodels.Find(id);
        //    if (assignTeacherToClassViewmodel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(assignTeacherToClassViewmodel);
        //}

        // POST: AssignTeacherToClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,StaffNumber,GradeGroupId")] AssignTeacherToClassViewmodel assignTeacherToClassViewmodel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(assignTeacherToClassViewmodel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(assignTeacherToClassViewmodel);
        //}

        // GET: AssignTeacherToClass/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AssignTeacherToClassViewmodel assignTeacherToClassViewmodel = db.AssignTeacherToClassViewmodels.Find(id);
        //    if (assignTeacherToClassViewmodel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(assignTeacherToClassViewmodel);
        //}

        //// POST: AssignTeacherToClass/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    AssignTeacherToClassViewmodel assignTeacherToClassViewmodel = db.AssignTeacherToClassViewmodels.Find(id);
        //    db.AssignTeacherToClassViewmodels.Remove(assignTeacherToClassViewmodel);
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
