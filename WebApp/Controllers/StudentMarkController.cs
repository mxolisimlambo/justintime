using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using WebApp.Business;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;
using WebApp.Models;
using WebApp.Business.BusinessBL;

namespace WebApp.Controllers
{
    public class StudentMarkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        StudentMarkBL logic = new StudentMarkBL();

        // GET: StudentMark
        public ActionResult Index()
        {
            //var studentMarkViewModels = db.Include(s => s.ClassGroupe).Include(s => s.Subjects);

            return View(/*logic.GetAllStudentMark().ToList()*/);
        }

        // GET: StudentMark/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StudentMarks studentMarkViewModel = db.Studentmark.Find(id);
        //    if (studentMarkViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(studentMarkViewModel);
        //}

        // GET: StudentMark/Create
        public ActionResult Create()
        {
            ViewBag.GroupeName = new SelectList(db.ClassGroupes, "GroupeName", "GroupeName");
            ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "ClassGroupe_id");
            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "DescriptiveTitle");
            return View();
        }

        // POST: StudentMark/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_Number,Student_Name,ClassGroupe_id,GroupeName,Subject_Code,mark,result")] StudentMarkViewModel studentMarkViewModel)
        {
            if (ModelState.IsValid)
            {

                logic.AddStudentMark(studentMarkViewModel);
                return RedirectToAction("Filter");
            }
            ViewBag.GroupeName = new SelectList(db.ClassGroupes, "GroupeName", "GroupeName", studentMarkViewModel.GroupeName);
            ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName", studentMarkViewModel.ClassGroupe_id);
            ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "DescriptiveTitle", studentMarkViewModel.Subject_Code);
            return View(studentMarkViewModel);
        }

        //public ActionResult Seach(string AppID)
        //{
        //    ApplicationTable stu = db.ApplicationTables.Find(AppID);
        //    if (stu != null)
        //    {
        //        var take = from r in db.ApplicationTables.ToList()
        //                   select r;

        //        if (!String.IsNullOrEmpty(AppID))
        //        {
        //            TempData["AppID"] = AppID;
        //            take = db.ApplicationTables.Where(s => s.Applicant_IDNumber.Contains(AppID));
        //        }
        //        return RedirectToAction("Create");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        [HttpGet]
        public ActionResult CaptureMark()
        {
            //logic.GetAllStudentMark()
            return View(db.Studentmark.ToList());
        }

        public ActionResult CaptureMark(List<StudentMarks> list)
        {
            try
            {

                logic.EditMark(list);
                ViewBag.message = "Successfully Updated.";
                return View(list);
            }
            catch(Exception t)
            {
                ViewBag.message = "Capture Failed Had an error..";
                return View(list);
            }

        }








        public ActionResult Filter(string GroupG, string SubjectT)
        {
            var grouplist = new List<string>();

            var grouponqury = from t in db.Studentmark
                              orderby t.GroupeName
                              select t.GroupeName;


            grouplist.AddRange(grouponqury.Distinct());
            ViewBag.GroupG = new SelectList(grouplist);



            var Sublist = new List<string>();

            var subjectquery = from t in db.Studentmark
                               orderby t.Subject_Code
                               select t.Subject_Code;

            Sublist.AddRange(subjectquery.Distinct());
            ViewBag.SubjectT = new SelectList(Sublist);

            var m = from y in db.Studentmark
                    select y;


            if (!String.IsNullOrEmpty(SubjectT))
            {

                m = m.Where(c => c.Subject_Code == (SubjectT));
            }
            if (!String.IsNullOrEmpty(GroupG))
            {

                m = m.Where(v => v.GroupeName == GroupG);
            }

            return View(m);

        }



















        // GET: StudentMark/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //   StudentMarks studentMarkViewModel = db.Studentmark.Find(id);
        //    if (studentMarkViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName", studentMarkViewModel.ClassGroupe_id);
        //    ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "DescriptiveTitle", studentMarkViewModel.Subject_Code);
        //    return View(studentMarkViewModel);
        //}

        // POST: StudentMark/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Student_Number,Student_Name,ClassGroupe_id,GroupeName,Subject_Code,mark,result")] StudentMarkViewModel studentMarkViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(studentMarkViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName", studentMarkViewModel.ClassGroupe_id);
        //    ViewBag.Subject_Code = new SelectList(db.Subjects, "Subject_Code", "DescriptiveTitle", studentMarkViewModel.Subject_Code);
        //    return View(studentMarkViewModel);
        //}

        // GET: StudentMark/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StudentMarkViewModel studentMarkViewModel = db.StudentMarkViewModels.Find(id);
        //    if (studentMarkViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(studentMarkViewModel);
        //}

        // POST: StudentMark/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    //StudentMarkViewModel studentMarkViewModel = db.StudentMarkViewModels.Find(id);
        //    //db.StudentMarkViewModels.Remove(studentMarkViewModel);
        //    //db.SaveChanges();
        //    //return RedirectToAction("Index");
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
