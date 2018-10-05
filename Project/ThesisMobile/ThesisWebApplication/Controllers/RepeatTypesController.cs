using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThesisWebApplication.Models;

namespace ThesisWebApplication.Controllers
{
    public class RepeatTypesController : Controller
    {
        private ThesisDBEntities db = new ThesisDBEntities();

        // GET: RepeatTypes
        public ActionResult Index()
        {
            return View(db.RepeatTypes.ToList());
        }

        // GET: RepeatTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepeatType repeatType = db.RepeatTypes.Find(id);
            if (repeatType == null)
            {
                return HttpNotFound();
            }
            return View(repeatType);
        }

        // GET: RepeatTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepeatTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RepeatType1")] RepeatType repeatType)
        {
            if (ModelState.IsValid)
            {
                db.RepeatTypes.Add(repeatType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repeatType);
        }

        // GET: RepeatTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepeatType repeatType = db.RepeatTypes.Find(id);
            if (repeatType == null)
            {
                return HttpNotFound();
            }
            return View(repeatType);
        }

        // POST: RepeatTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RepeatType1")] RepeatType repeatType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repeatType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repeatType);
        }

        // GET: RepeatTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepeatType repeatType = db.RepeatTypes.Find(id);
            if (repeatType == null)
            {
                return HttpNotFound();
            }
            return View(repeatType);
        }

        // POST: RepeatTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepeatType repeatType = db.RepeatTypes.Find(id);
            db.RepeatTypes.Remove(repeatType);
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
