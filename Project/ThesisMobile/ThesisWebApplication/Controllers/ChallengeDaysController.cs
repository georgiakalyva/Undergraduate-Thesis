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
    public class ChallengeDaysController : Controller
    {
        private ThesisDBEntities db = new ThesisDBEntities();

        // GET: ChallengeDays
        public ActionResult Index()
        {
            var challengeDays = db.ChallengeDays.Include(c => c.Challenge);
            return View(challengeDays.ToList());
        }

        // GET: ChallengeDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeDay challengeDay = db.ChallengeDays.Find(id);
            if (challengeDay == null)
            {
                return HttpNotFound();
            }
            return View(challengeDay);
        }

        // GET: ChallengeDays/Create
        public ActionResult Create()
        {
            ViewBag.ChallengeID = new SelectList(db.Challenges, "ID", "ChallengeTitle");
            return View();
        }

        // POST: ChallengeDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Day,ChallengeID,RepeatCircuit,Title")] ChallengeDay challengeDay)
        {
            if (ModelState.IsValid)
            {
                db.ChallengeDays.Add(challengeDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChallengeID = new SelectList(db.Challenges, "ID", "ChallengeTitle", challengeDay.ChallengeID);
            return View(challengeDay);
        }

        // GET: ChallengeDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeDay challengeDay = db.ChallengeDays.Find(id);
            if (challengeDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChallengeID = new SelectList(db.Challenges, "ID", "ChallengeTitle", challengeDay.ChallengeID);
            return View(challengeDay);
        }

        // POST: ChallengeDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Day,ChallengeID,RepeatCircuit,Title")] ChallengeDay challengeDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(challengeDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChallengeID = new SelectList(db.Challenges, "ID", "ChallengeTitle", challengeDay.ChallengeID);
            return View(challengeDay);
        }

        // GET: ChallengeDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChallengeDay challengeDay = db.ChallengeDays.Find(id);
            if (challengeDay == null)
            {
                return HttpNotFound();
            }
            return View(challengeDay);
        }

        // POST: ChallengeDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChallengeDay challengeDay = db.ChallengeDays.Find(id);
            db.ChallengeDays.Remove(challengeDay);
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
