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
    public class ClassMarkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ClassMarkBL logic = new ClassMarkBL();
        private StudentMarkBL stLogic = new StudentMarkBL();
        // GET: ClassMark
        public ActionResult Index()
        {

            return View(logic.GetAllClassMark());
        }

        // GET: ClassMark/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClassMarkViewModel classMarkViewModel = db.ClassMarkViewModels.Find(id);
        //    if (classMarkViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(classMarkViewModel);
        //}
        public ActionResult ClassList()
        {
            return View(/*stLogic.GetAllStudentMark()*/);
        }
        [HttpPost]
        public ActionResult ClassList(string Stud,string ClassT)
        {
        
            var Grouplist = new List<string>();

            var Groupquery = from t in db.Studentmark
                               orderby t.GroupeName
                               select t.GroupeName;

            Grouplist.AddRange(Groupquery.Distinct());
            ViewBag.ClassT = new SelectList(Grouplist);


            var getList = from t in db.Studentmark
                          select t;


            if (!String.IsNullOrEmpty(Stud))
            {

                getList = getList.Where(c => c.Student_Number.Contains(Stud));
            }
            if (!String.IsNullOrEmpty(ClassT))
            {

                getList = getList.Where(v => v.GroupeName == ClassT);
            }

            return View(getList);

        }

        // GET: ClassMark/Create
        public ActionResult Create()
        {
            ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName");
            return View();
        }

        // POST: ClassMark/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_No,Student_name,ClassGroupe_id,Subject1,mark,Subject2,mark21,Subject3,mark12,Subject4,mark23,Subject5,mark32")] ClassMarkViewModel classMarkViewModel)
        {
            if (ModelState.IsValid)
            {

                logic.AppClassMark(classMarkViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName", classMarkViewModel.ClassGroupe_id);
            return View(classMarkViewModel);
        }

        // GET: ClassMark/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClassMarkViewModel classMarkViewModel = db.ClassMarkViewModels.Find(id);
        //    if (classMarkViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName", classMarkViewModel.ClassGroupe_id);
        //    return View(classMarkViewModel);
        //}

        // POST: ClassMark/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Student_No,Student_name,ClassGroupe_id,Subject1,mark,Subject2,mark21,Subject3,mark12,Subject4,mark23,Subject5,mark32")] ClassMarkViewModel classMarkViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(classMarkViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName", classMarkViewModel.ClassGroupe_id);
        //    return View(classMarkViewModel);
        //}

        //// GET: ClassMark/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ClassMarkViewModel classMarkViewModel = db.ClassMarkViewModels.Find(id);
        //    if (classMarkViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(classMarkViewModel);
        //}

        //// POST: ClassMark/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    ClassMarkViewModel classMarkViewModel = db.ClassMarkViewModels.Find(id);
        //    db.ClassMarkViewModels.Remove(classMarkViewModel);
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
