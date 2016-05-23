using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class AttendReccordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AttendReccords
        public ActionResult Index(string searchby,string studentNo)
        {
            if(searchby == "Day")
            {
                return View(db.AttendReccords.Where(x => x.Day == studentNo || studentNo == null).ToList());
            }
            if(searchby== "Class")
            {
                return View(db.AttendReccords.Where(x => x.GradeGroupID == studentNo || studentNo == null).ToList());
            }
            else
            {
                return View(db.AttendReccords.Where(x => x.StudentNo.StartsWith(studentNo) || studentNo == null).ToList());
            }
            
            
        }

        // GET: AttendReccords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendReccord attendReccord = db.AttendReccords.Find(id);
            if (attendReccord == null)
            {
                return HttpNotFound();
            }
            return View(attendReccord);
        }

        // GET: AttendReccords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttendReccords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttendReccordID,StudentNo,StudentName,GradeGroupID,Day,Date,Attends,Absent,Await,Remark")] AttendReccord attendReccord)
        {
            if (ModelState.IsValid)
            {
                db.AttendReccords.Add(attendReccord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendReccord);
        }

        // GET: AttendReccords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendReccord attendReccord = db.AttendReccords.Find(id);
            if (attendReccord == null)
            {
                return HttpNotFound();
            }
            return View(attendReccord);
        }

        // POST: AttendReccords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendReccordID,StudentNo,GradeGroupID,StudentName,Day,Date,Attends,Absent,Await,Remark")] AttendReccord attendReccord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendReccord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendReccord);
        }

        // GET: AttendReccords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendReccord attendReccord = db.AttendReccords.Find(id);
            if (attendReccord == null)
            {
                return HttpNotFound();
            }
            return View(attendReccord);
        }

        // POST: AttendReccords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendReccord attendReccord = db.AttendReccords.Find(id);
            db.AttendReccords.Remove(attendReccord);
            db.SaveChanges();
            return RedirectToAction("Index");
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
