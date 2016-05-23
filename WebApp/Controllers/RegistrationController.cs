using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using WebApp.Business.BusinessBL;
using System.Web.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        RegistrationBL logic = new RegistrationBL();
        public RegistrationController() { }
        public RegistrationController(RegistrationBL Reg)
        {
            this.logic = Reg;
        }

        // GET: Registration
        //public ActionResult Index()
        //{
        //    var registrationViewModels = db.RegistrationViewModels.Include(r => r.ClassGroupe).Include(r => r.Parent).Include(r => r.StreamTable);
        //    return View(registrationViewModels.ToList());
        //}

        // GET: Registration/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
        //    if (registrationViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(registrationViewModel);
        //}

        //// GET: Registration/Create
        public ActionResult Create()
        {

            int count = db.StudentTables.ToList().Count();
           var tr = DateTime.Now.Year + count.ToString();
            RegistrationViewModel reg = new RegistrationViewModel {Student_Number=tr.ToString() };
            ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName");
            //ViewBag.Parent_Identity = new SelectList(db.Parents, "Parent_Identity", "Title");
            ViewBag.Stream_Code = new SelectList(db.StreamTables, "Stream_Code", "Description");
            return View(reg);
        }

        // POST: Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_Number,Student_IDNumber,Student_Name,Student_Surname,Student_Date_Of_Birth,Enrolment_Date,Student_Gender,Student_Religion,Student_Adress,Grade_id,ClassGroupe_id,Stream_Code,Role,AddPhoto,status,Parent_Identity,Title,Parent_Name,Parent_Surname,Parent_Number,Parent_Adress,Parent_Email")] RegistrationViewModel registrationViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {

                logic.Register(registrationViewModel,image);

                //string schoolfees = "School Fees: R150.00";
                //TempData["mesage1"] = student.Student_No;
                //TempData["mesage2"] = student.Student_Name;
                //TempData["mesage3"] = student.Student_Surname;
                //TempData["mesage4"] = student.Steams_id;
                //TempData["mesage5"] = student.GradeID;
                //TempData["mesage6"] = schoolfees;

              
                return RedirectToAction("Index");
            }

            ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName", registrationViewModel.ClassGroupe_id);
            //ViewBag.Parent_Identity = new SelectList(db.Parents, "Parent_Identity", "Title", registrationViewModel.Parent_Identity);
            ViewBag.Stream_Code = new SelectList(db.StreamTables, "Stream_Code", "Description", registrationViewModel.Stream_Code);
            return View();
        }

     
        // GET: Registration/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
        //    if (registrationViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName", registrationViewModel.ClassGroupe_id);
        //    ////ViewBag.Parent_Identity = new SelectList(db.Parents, "Parent_Identity", "Title", registrationViewModel);
        //    ViewBag.Stream_Code = new SelectList(db.StreamTables, "Stream_Code", "Description", registrationViewModel.Stream_Code);
        //    return View(registrationViewModel);
        //}

        // POST: Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_Number,Student_IDNumber,Student_Name,Student_Surname,Student_Date_Of_Birth,Enrolment_Date,Student_Gender,Student_Religion,Student_Adress,Grade_id,ClassGroupe_id,Stream_Code,Role,AddPhoto,status,Parent_Identity,Title,Parent_Name,Parent_Surname,Parent_Number,Parent_Adress,Parent_Email")] RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassGroupe_id = new SelectList(db.ClassGroupes, "ClassGroupe_id", "GroupeName", registrationViewModel.ClassGroupe_id);
            ViewBag.Parent_Identity = new SelectList(db.Parents, "Parent_Identity", "Title", registrationViewModel.Parent_Identity);
            ViewBag.Stream_Code = new SelectList(db.StreamTables, "Stream_Code", "Description", registrationViewModel.Stream_Code);
            return View(registrationViewModel);
        }

        // GET: Registration/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
        //    if (registrationViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(registrationViewModel);
        //}

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
        //    db.RegistrationViewModels.Remove(registrationViewModel);
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
