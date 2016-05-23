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
    public class StreamTableViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private StreamTableBL streamtablebl = new StreamTableBL();

        public StreamTableViewModelsController() { }

        public StreamTableViewModelsController (StreamTableBL streamtablebl)
        {
            this.streamtablebl = streamtablebl;
        }
        // GET: StreamTableViewModels
        public ActionResult Index()
        {
            return View(streamtablebl.GetAllStreams());
        }

        // GET: StreamTableViewModels/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StreamTableViewModel streamTableViewModel = db.StreamTableViewModels.Find(id);
        //    if (streamTableViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(streamTableViewModel);
        //}

        // GET: StreamTableViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StreamTableViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stream_Code,Description")] StreamTableViewModel streamTableViewModel)
        {
            if (ModelState.IsValid)
            {
                streamtablebl.AddStream(streamTableViewModel);
                return RedirectToAction("Index");
            }

            return View(streamTableViewModel);
        }

        // GET: StreamTableViewModels/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StreamTableViewModel streamTableViewModel = db.StreamTableViewModels.Find(id);
        //    if (streamTableViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(streamTableViewModel);
        //}

        // POST: StreamTableViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Stream_Code,Description")] StreamTableViewModel streamTableViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(streamTableViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(streamTableViewModel);
        //}

        // GET: StreamTableViewModels/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StreamTableViewModel streamTableViewModel = db.StreamTableViewModels.Find(id);
        //    if (streamTableViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(streamTableViewModel);
        //}

        // POST: StreamTableViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    StreamTableViewModel streamTableViewModel = db.StreamTableViewModels.Find(id);
        //    db.StreamTableViewModels.Remove(streamTableViewModel);
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
