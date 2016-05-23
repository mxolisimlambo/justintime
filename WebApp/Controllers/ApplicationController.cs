using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Business.BusinessBL;
using WebApp.Contact;
using WebApp.CustomDropdownLists;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ApplicationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        private readonly ApplicationBL _logic = new ApplicationBL();
        private Gender gnd = new Gender();
        private AppStatus appstatus = new AppStatus();
        public ApplicationController() { }
        public ApplicationController(ApplicationBL applicantbl)
        {
            _logic = applicantbl;
        }

        // GET: ApplicationViewModels
        public ActionResult Apply()
        {

            ViewBag.Gender = new SelectList(gnd.GetGenders(), dataValueField: "GenderTitle", dataTextField: "GenderTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(MakeApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logic.MakeApplication(model);
                ContactMethod.SendSms(model.Phone, "Application to attend JG Zuma High was received. You will receive feedback within 15 days.");
                return RedirectToAction("ApplicationSuccess");
            }
            ViewBag.Gender = new SelectList(gnd.GetGenders(), dataValueField: "GenderTitle", dataTextField: "GenderTitle", selectedValue: gnd.GenderTitle);
            return View(model);
        }

        public ActionResult ApplicationSuccess()
        {
            return View();
        }

        // GET: Applications
        public ActionResult Index()
        {
            ViewBag.Status = new SelectList(appstatus.GetStatuses(), dataValueField: "Status", dataTextField: "Status");
            return View(_logic.GetAllApplications());
        }

        public FileContentResult ViewReport(string id)
        {
            var app = _logic.GetApplication(id);

            return new FileContentResult(app.ReportCopy, "application/pdf");
        }

        //[HttpPost]
        public ActionResult UpdateStatus(string id)
        {
            var app = _logic.GetApplication(id);

            _logic.UpdateStatus(app);
            if (app.Status.Equals("Accepted"))
            {
                string message = "Dear applicant, please be advised that your application was approved. You will be notified about the date of registration";
                ContactMethod.SendSms(app.Phone, message);
            }

            return View(app);
        }
    }
}
