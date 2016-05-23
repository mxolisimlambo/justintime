using Microsoft.AspNet.Identity.Owin;
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
    public class StaffViewModelsController : Controller
    {
      
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUser _userManager;

        public StaffViewModelsController()
        {


        }
        public ApplicationUser UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUser>(); }

            private set { _userManager = value; }
        }
        readonly StaffBL _staff = new StaffBL();
        public ActionResult Index(int? page, string FName)
        {
          
           
            var x = new StaffBL();

            if (FName != null)
            {

                return View(x.SearchByName(FName));
            }
            else
            {

                return View(x.GetAllStaff());
            }
        }

        // GET: StaffViewModels
       

        // GET: StaffViewModels/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //   // StaffViewModel staffViewModel = db.StaffViewModels.Find(id);
        //    if (staffViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(staffViewModel);
        //}

        // GET: StaffViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StaffViewModel staffViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
               
                _staff.AddNewStaffprofile(staffViewModel, image);

                return RedirectToAction("Index");
            }

            return View(staffViewModel);
        }

        // GET: StaffViewModels/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StaffViewModel staffViewModel = db.StaffViewModels.Find(id);
        //    if (staffViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(staffViewModel);
        //}

        // POST: StaffViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserProfileId,UserName,FirstName,LastName,Email,Password,Gender,IdentityNumber,ContactNumber,Role,AddPhoto")] StaffViewModel staffViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(staffViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(staffViewModel);
        //}

        // GET: StaffViewModels/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StaffViewModel staffViewModel = db.StaffViewModels.Find(id);
        //    if (staffViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(staffViewModel);
        //}

        // POST: StaffViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    StaffViewModel staffViewModel = db.StaffViewModels.Find(id);
        //    db.StaffViewModels.Remove(staffViewModel);
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
