using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ThesisWebApplication.Models;

namespace ThesisWebApplication
{
    public class ChallengesController : ApiController
    {
        private ThesisDBEntities db = new ThesisDBEntities();

        // GET: api/Challenges
        public List<JCategory> GetChallenges()
        {
            List<RepeatType> RepeatTypes = db.RepeatTypes.ToList();
            List<CategoryType> CategoryTypes = db.CategoryTypes.ToList();


            List<JCategory> Categories = (from cat in db.Categories
                                          select new JCategory()
                                          {
                                              ID = cat.ID,
                                              CategoryDescription = cat.CategoryDescription,
                                              CategoryImage = cat.CategoryImage,
                                              CategoryName = cat.CategoryName,
                                              CategoryType = cat.CategoryType,
                                              Challenges = (from cha in db.Challenges
                                                            where cat.ID == cha.CategoryID && cha.IsActive == true
                                                            select new JChallenge()
                                                            {
                                                                ID = cha.ID,
                                                                ChallengeTitle = cha.ChallengeTitle,
                                                                ChallengeDescription = cha.ChallengeDescription,
                                                                ChallengeImage = cha.ChallengeImage,
                                                                ChallengeDayExersices = (from cde in db.ChallengeDayExersices
                                                                                         where cde.ChallengeID == cha.ID && cha.IsActive == true
                                                                                         select new JChallengeDayExersice()
                                                                                         {
                                                                                             ID = cde.ID,
                                                                                             ChallengeID = cha.ID,
                                                                                             DayID = cde.DayID,
                                                                                             RepeatCircuit = cde.RepeatCircuit,
                                                                                             Repeats = cde.Repeats,
                                                                                             RepeatType = cde.RepeatType,
                                                                                             Exercise = new JExercise()
                                                                                             {
                                                                                                 ID = cde.Exercise.ID,
                                                                                                 ExerciseName = cde.Exercise.ExerciseName,
                                                                                                 ExerciseImage = cde.Exercise.ExerciseImage
                                                                                             }
                                                                                             
                                                                                         }).ToList()
                                                            }).ToList()
                                              
                                          }).ToList();


            //string output = JsonConvert.SerializeObject(Categories, Formatting.Indented);

            return Categories;
        }

        // GET: api/Challenges/5
        [ResponseType(typeof(Challenge))]
        public IHttpActionResult GetChallenge(int id)
        {
            Challenge challenge = db.Challenges.Find(id);
            if (challenge == null)
            {
                return NotFound();
            }

            return Ok(challenge);
        }

        // PUT: api/Challenges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChallenge(int id, Challenge challenge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != challenge.ID)
            {
                return BadRequest();
            }

            db.Entry(challenge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChallengeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Challenges
        [ResponseType(typeof(Challenge))]
        public IHttpActionResult PostChallenge(Challenge challenge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Challenges.Add(challenge);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = challenge.ID }, challenge);
        }

        // DELETE: api/Challenges/5
        [ResponseType(typeof(Challenge))]
        public IHttpActionResult DeleteChallenge(int id)
        {
            Challenge challenge = db.Challenges.Find(id);
            if (challenge == null)
            {
                return NotFound();
            }

            db.Challenges.Remove(challenge);
            db.SaveChanges();

            return Ok(challenge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChallengeExists(int id)
        {
            return db.Challenges.Count(e => e.ID == id) > 0;
        }
    }
    
       
    }
