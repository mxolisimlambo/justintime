using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Business.BusinessBL;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ApplicationViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        private readonly ApplicationTableBL _applicanttBl = new ApplicationTableBL();

        public ApplicationViewModelsController() { }
        public ApplicationViewModelsController(ApplicationTableBL applicantbl)
        {
            _applicanttBl = applicantbl;
        }

        // GET: ApplicationViewModels
        public ActionResult Index()
        {
            return View(_applicanttBl.GetAllApplicants());
        }

        // GET: ApplicationViewModels/Details/5
        public ActionResult Details(string id)
        {
            return View(_applicanttBl.GetById(id));

        }

        // GET: ApplicationViewModels/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ApplicationViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Applicant_id,Applicant_IDNumber,Applicant_Name,Applicant_Surname,Applicant_Date_Of_Birth,Applicant_Gender,Applicant_Religion,Applicant_Adress,Application_Grade,Maths_Mark,English_Mark,ZuluHomeLanguage_Mark,status,Title,Parent_Name,Parent_Surname,Parent_Number,Parent_Adress,Parent_Email")] ApplicationViewModel applicationViewModel)
        {
            if (ModelState.IsValid)
            {
                _applicanttBl.AddApplicant(applicationViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationViewModel);
        }

        // GET: ApplicationViewModels/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_applicanttBl.GetById(id));
        }

        // POST: ApplicationViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Applicant_id,Applicant_IDNumber,Applicant_Name,Applicant_Surname,Applicant_Date_Of_Birth,Applicant_Gender,Applicant_Religion,Applicant_Adress,Application_Grade,Maths_Mark,English_Mark,ZuluHomeLanguage_Mark,status,Title,Parent_Name,Parent_Surname,Parent_Number,Parent_Adress,Parent_Email")] ApplicationViewModel applicationViewModel)
        {
            if (ModelState.IsValid)
            {
                _applicanttBl.UpdateApplicant(applicationViewModel);
                return RedirectToAction("Index");
            }
            return View(applicationViewModel);
        }

        // GET: ApplicationViewModels/Delete/5
        public ActionResult Delete(string id)
        {

            return View(_applicanttBl.GetById(id));
        }

        // POST: ApplicationViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _applicanttBl.RemoveApplicant(id);
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
