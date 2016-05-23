using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using WebApp.Business.BusinessBL;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GradesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        GradeBL logic = new GradeBL();

        // GET: Grades
        public ActionResult Index()
        {
            return View(logic.GetAllGroup());
        }

        // GET: Grades/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GradesViewModels gradesViewModels = db.GradesViewModels.Find(id);
        //    if (gradesViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gradesViewModels);
        //}

        // GET: Grades/Create
        public ActionResult Create()
        {
           
           
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Grade_id,GradeName")] GradesViewModels gradesViewModels)
        {
            if (ModelState.IsValid)
            {
                logic.AddGroup(gradesViewModels);
               
                return RedirectToAction("Index");
            }

            return View(gradesViewModels);
        }

        // GET: Grades/Edit/5
        public ActionResult Edit(int id)
        {
            return View(logic.GetById(id));
        }
    
        // POST: Grades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Grade_id,GradeName")] GradesViewModels gradesViewModels)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(gradesViewModels).State = EntityState.Modified;
                //db.SaveChanges();
                logic.UpdateGroup(gradesViewModels);
                return RedirectToAction("Index");
            }
            return View(gradesViewModels);
        }

        // GET: Grades/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GradesViewModels gradesViewModels = db.GradesViewModels.Find(id);
        //    if (gradesViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gradesViewModels);
        //}

        // POST: Grades/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    GradesViewModels gradesViewModels = db.GradesViewModels.Find(id);
        //    db.GradesViewModels.Remove(gradesViewModels);
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
