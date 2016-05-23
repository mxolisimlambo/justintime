using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class ReportController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Report
        public ActionResult Index()
        {
            return View(db.StudentTables.ToList());
        }

        public ActionResult Mark(String ID)
        {
            List<Mark> mark = new List<Mark>();
            var stud = db.StudentTables.Find(ID);
            //var stud = db.Students.Where(c => c.StudentID == ID);
            if (stud != null)
            {
                ViewBag.Id = stud.Student_Number;
                ViewBag.Name = stud.Student_Name +" "+stud.Student_Surname;
                ViewBag.Age = stud.Grades.GradeName;
                mark = db.Marks.ToList().FindAll(x => x.StudentID.Equals(ID));
            }
            return View(mark);
        }

        public ActionResult June_Exam(String ID)
        {
            List<Mark> mark = new List<Mark>();
            var stud = db.StudentTables.Find(ID);
            //var stud = db.Students.Where(c => c.StudentID == ID);
            if (stud != null)
            {
                ViewBag.Id = stud.Student_Number;
                ViewBag.Name = stud.Student_Name + " " + stud.Student_Surname;
                ViewBag.Age = stud.Grades.GradeName;
                mark = db.Marks.ToList().FindAll(x => x.StudentID.Equals(ID));
            }
            return View(mark);
        }

        public ActionResult TermThree(String ID)
        {
            List<Mark> mark = new List<Mark>();
            var stud = db.StudentTables.Find(ID);
            //var stud = db.Students.Where(c => c.StudentID == ID);
            if (stud != null)
            {
                ViewBag.Id = stud.Student_Number;
                ViewBag.Name = stud.Student_Name + " " + stud.Student_Surname;
                ViewBag.Age = stud.Grades.GradeName;
                mark = db.Marks.ToList().FindAll(x => x.StudentID.Equals(ID));
            }
            return View(mark);
        }

        public ActionResult Final_Exam(String ID)
        {
            List<Mark> mark = new List<Mark>();
            var stud = db.StudentTables.Find(ID);
            //var stud = db.Students.Where(c => c.StudentID == ID);
            if (stud != null)
            {
                ViewBag.Id = stud.Student_Number;
                ViewBag.Name = stud.Student_Name + " " + stud.Student_Surname;
                ViewBag.Age = stud.Grades.GradeName;
                mark = db.Marks.ToList().FindAll(x => x.StudentID.Equals(ID));
            }
            return View(mark);
        }
    }
}