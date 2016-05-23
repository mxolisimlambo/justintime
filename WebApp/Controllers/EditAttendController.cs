using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class EditAttendController : Controller
    {
        // GET: EditAttend
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

        //    StudentTable cls = new StudentTable();
        //    var data = from item in db.StudentTables
        //               where item.studentlastname == "maths"
        //               //orderby item.id
        //               select item;
            return View();


        }
        //[httppost]
        //public actionresult index(list<studenttable> classs)
        //{


        //    foreach (studenttable emp in db.studenttables)
        //    {
        //        studenttable existed_emp = db.studenttables.find(emp.studentid);
        //        existed_emp.studentname = emp.studentname;
        //        existed_emp.studentlastname = emp.studentlastname;


        //    }

        //    db.savechanges();
        //    return view();
        //}
        public ActionResult RdBtnList(Attend model)
        {

            return View(model);
        }
        public ActionResult Edit()
        {
            return View(db.Attends.ToList());
        }
        [HttpPost]
        public ActionResult Edit(List<Attend> list)
        {

            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    AttendReccord at = new AttendReccord();
                    foreach (var i in list)
                    {
                        var c = db.Attends.Where(a => a.AttendID.Equals(i.AttendID)).FirstOrDefault();
                        if (c != null)
                        {
                            c.StudentNo = i.StudentNo;
                            c.StudentName = i.StudentName;
                            c.GradeGroupID = i.GradeGroupID;
                            c.Day = i.Day;
                            c.Date = i.Date;
                            c.Attends = i.Attends;
                            c.Await = i.Await;
                            c.Absent = i.Absent;
                            c.Remark = i.Remark;

                            at.StudentNo = i.StudentNo;
                            at.StudentName = i.StudentName;
                            at.GradeGroupID = i.GradeGroupID;
                            at.Date = i.Date;
                            at.Day = i.Day;
                            at.Attends = i.Attends;
                            at.Absent = i.Absent;
                            at.Await = i.Await;
                            at.Remark = i.Remark;
                           // db.SaveChanges();
                        }
                    }

                    db.AttendReccords.Add(at);
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
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Attend model)
        {
            if (ModelState.IsValid)
            {
               

                Attend tak = new Attend
                {
                StudentNo = model.StudentNo,
                StudentName = model.StudentName,
                GradeGroupID=model.GradeGroupID,
                Date = model.Date,
                Day = model.Day,
                Attends = model.Attends,
                Await = model.Await,
                Absent = model.Absent,
                Remark = model.Remark,
            };
                db.Attends.Add(tak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

      
        
        public ActionResult Fillter(string GroupG)
        {
            var grouplist = new List<string>();

            var grouponqury = from t in db.Attends
                              orderby t.GradeGroupID
                              select t.GradeGroupID;


            grouplist.AddRange(grouponqury.Distinct());
            ViewBag.GroupG = new SelectList(grouplist);




            List<Attend> marklist = new List<Attend>();
            var m = from y in db.Attends
                    select y;



            if (!String.IsNullOrEmpty(GroupG))
            {

                m = m.Where(v => v.GradeGroupID == GroupG);
            }

            var myEmpList = m.ToList();
            foreach (var empData in myEmpList)
            {
                marklist.Add(new Attend()
                {
                    StudentNo = empData.StudentNo,
                    StudentName = empData.StudentName,
                    GradeGroupID = empData.GradeGroupID,
                    Date = empData.Date,
                    Day = empData.Day,
                    Attends = empData.Attends,
                    Await = empData.Await,
                    Absent = empData.Absent,
                    Remark = empData.Remark,
                });

            }
                return View(marklist);

        }

        }

    }
