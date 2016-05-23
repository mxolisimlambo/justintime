using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using WebApp.Models;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class MarksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Marks


        public JsonResult ChangeUser(Mark model)
        {
            // Update model to your db
            string message = "Mark Captured Successfully";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string GroupG ,string stud)
        {
            var grouplist = new List<string>();

            var grouponqury = from t in db.Marks
                              orderby t.ClassGroupID
                              select t.ClassGroupID;


            grouplist.AddRange(grouponqury.Distinct());
            ViewBag.GroupG = new SelectList(grouplist);


            //string SUB = id;
            //var Sublist = new List<string>();

            //var subjectquery = from t in db.Marks
            //                   orderby t.Subject_Code
            //                   select t.Subject_Code;

            //Sublist.AddRange(subjectquery.Distinct());
            //ViewBag.SUB = new SelectList(Sublist);

            var m = from y in db.Marks
                    select y;


            if (!String.IsNullOrEmpty(stud))
            {

                m = m.Where(c => c.StudentID.Contains(stud));
            }
            if (!String.IsNullOrEmpty(GroupG))
            {

                m = m.Where(v => v.ClassGroupID == GroupG);
            }

            return View(m);
        }
// GET: Marks/Details/5
public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // GET: Marks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Markid,ClassGroupID,Subject_Code,Term1,Term2,Term3,Term4,StudentID")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                db.Marks.Add(mark);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Create");
            }

            return View(mark);
        }

        // GET: Marks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Markid,ClassGroupID,Subject_Code,Term1,Term2,Term3,Term4,StudentID")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mark);
        }

        // GET: Marks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mark mark = db.Marks.Find(id);
            db.Marks.Remove(mark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Fillter(string GroupG, string SUB)
        {
            var grouplist = new List<string>();

            var grouponqury = from t in db.Marks
                              orderby t.ClassGroupID
                              select t.ClassGroupID;


            grouplist.AddRange(grouponqury.Distinct());
            ViewBag.GroupG = new SelectList(grouplist);


            //string  SUB= id;
            //var Sublist = new List<string>();

            //var subjectquery = from t in db.Marks
            //                   orderby t.Subject_Code
            //                   select t.Subject_Code;

            //Sublist.AddRange(subjectquery.Distinct());
            //ViewBag.SUB = new SelectList(Sublist);

            List<Mark> marklist = new List<Mark>();
            var m = from y in db.Marks
                    select y;


         
            if (!String.IsNullOrEmpty(GroupG))
            {

                m = m.Where(v => v.ClassGroupID == GroupG);
            }
            if (!String.IsNullOrEmpty(SUB))
            {

                m = m.Where(c => c.Subject_Code.Contains(SUB));
            }

            var myEmpList = m.ToList();

            foreach (var empData in myEmpList)
            {
                marklist.Add(new Mark()
                {
                    Markid=empData.Markid,
                    StudentID=empData.StudentID,
                    ClassGroupID=empData.ClassGroupID,
                    Subject_Code=empData.Subject_Code,
                    Term1=empData.Term1,
                    Term2=empData.Term2,
                    Term3=empData.Term3,
                    Term4=empData.Term4
                });
                
                  
                  
            }
            return View(marklist);

           

        }

        public ActionResult CaptureMark()
        {
            return View(db.Marks.ToList());
        }
        [HttpPost]
        public ActionResult CaptureMark(List<Mark> list)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    foreach (var i in list)
                    {
                        var c = db.Marks.Where(a => a.StudentID.Equals(i.StudentID)).FirstOrDefault();
                        if (c != null)
                        {
                            c.StudentID = i.StudentID;
                            //c.Student.Student_Name = i.Student.Student_Name;
                            c.ClassGroupID = i.ClassGroupID;
                            c.Subject_Code = i.Subject_Code;
                            c.Term1 = i.Term1;
                            c.Term2 = i.Term2;
                            c.Term3 = i.Term3;
                            c.Term4 = i.Term4;
                            Contact.ContactMethod.SendSms(c.Student.Parent.Parent_Number, "Dear Parent Marks for "+c.Student.Student_Name+"Have been Captured ");
                            //db.Entry(c).State = EntityState.Modified;
                        }
                    }

                    db.SaveChanges();
                }
                    ViewBag.Message = "Successfully Updated.";
                    return View(list);
              }
            else
            {
                ViewBag.Message = "Failed ! Please try again.";
                return View(list);
            }

            return View(list);
        }



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
