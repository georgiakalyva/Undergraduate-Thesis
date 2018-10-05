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
    [Authorize]
    public class ChallengeExercisesController : Controller
    {
        
        private ThesisDBEntities db = new ThesisDBEntities();

        // GET: ChallengeExersices
        public ActionResult Index()
        {
            var challengeDayExersices = db.ChallengeDayExersices.Include(c => c.Challenge).Include(c => c.Exercise).Include(c => c.RepeatType1);
            return View(challengeDayExersices.ToList());
        }

        // GET: ChallengeExersices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeDayExersice challengeDayExersice = db.ChallengeDayExersices.Find(id);
            if (challengeDayExersice == null)
            {
                return HttpNotFound();
            }
            return View(challengeDayExersice);
        }

        // GET: ChallengeExersices/Create
        public ActionResult Create()
        {
            ViewBag.ChallengeID = new SelectList(db.Challenges, "ID", "ChallengeTitle");
            ViewBag.ExersiceID = new SelectList(db.Exercises, "ID", "ExerciseName");
            ViewBag.RepeatType = new SelectList(db.RepeatTypes, "ID", "RepeatType1");
            return View();
        }

        // POST: ChallengeExersices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DayID,ChallengeID,ExersiceID,Repeats,RepeatType")] ChallengeDayExersice challengeDayExersice)
        {
            if (ModelState.IsValid)
            {
                db.ChallengeDayExersices.Add(challengeDayExersice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChallengeID = new SelectList(db.Challenges, "ID", "ChallengeTitle", challengeDayExersice.ChallengeID);
            ViewBag.ExersiceID = new SelectList(db.Exercises, "ID", "ExerciseName", challengeDayExersice.ExersiceID);
            ViewBag.RepeatType = new SelectList(db.RepeatTypes, "ID", "RepeatType1", challengeDayExersice.RepeatType);
            return View(challengeDayExersice);
        }

        // GET: ChallengeExersices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeDayExersice challengeDayExersice = db.ChallengeDayExersices.Find(id);
            if (challengeDayExersice == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChallengeID = new SelectList(db.Challenges, "ID", "ChallengeTitle", challengeDayExersice.ChallengeID);
            ViewBag.ExersiceID = new SelectList(db.Exercises, "ID", "ExerciseName", challengeDayExersice.ExersiceID);
            ViewBag.RepeatType = new SelectList(db.RepeatTypes, "ID", "RepeatType1", challengeDayExersice.RepeatType);
            return View(challengeDayExersice);
        }

        // POST: ChallengeExersices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DayID,ChallengeID,ExersiceID,Repeats,RepeatType")] ChallengeDayExersice challengeDayExersice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(challengeDayExersice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChallengeID = new SelectList(db.Challenges, "ID", "ChallengeTitle", challengeDayExersice.ChallengeID);
            ViewBag.ExersiceID = new SelectList(db.Exercises, "ID", "ExerciseName", challengeDayExersice.ExersiceID);
            ViewBag.RepeatType = new SelectList(db.RepeatTypes, "ID", "RepeatType1", challengeDayExersice.RepeatType);
            return View(challengeDayExersice);
        }

        // GET: ChallengeExersices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeDayExersice challengeDayExersice = db.ChallengeDayExersices.Find(id);
            if (challengeDayExersice == null)
            {
                return HttpNotFound();
            }
            return View(challengeDayExersice);
        }

        // POST: ChallengeExersices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChallengeDayExersice challengeDayExersice = db.ChallengeDayExersices.Find(id);
            db.ChallengeDayExersices.Remove(challengeDayExersice);
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
