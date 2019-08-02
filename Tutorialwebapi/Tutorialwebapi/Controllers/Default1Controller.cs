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
using Tutorialwebapi.Models;

namespace Tutorialwebapi.Controllers
{
    public class Default1Controller : ApiController
    {
        private Dbmodels db = new Dbmodels();

        // GET api/Default1
        public IQueryable<Coursepost> GetCourseposts()
        {
            return db.Courseposts;
        }

        // GET api/Default1/5
        [ResponseType(typeof(Coursepost))]
        public IHttpActionResult GetCoursepost(long id)
        {
            Coursepost coursepost = db.Courseposts.Find(id);
            if (coursepost == null)
            {
                return NotFound();
            }

            return Ok(coursepost);
        }

        // PUT api/Default1/5
        public IHttpActionResult PutCoursepost(long id, Coursepost coursepost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coursepost.id)
            {
                return BadRequest();
            }

            db.Entry(coursepost).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursepostExists(id))
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

        // POST api/Default1
        [ResponseType(typeof(Coursepost))]
        public IHttpActionResult PostCoursepost(Coursepost coursepost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courseposts.Add(coursepost);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coursepost.id }, coursepost);
        }

        // DELETE api/Default1/5
        [ResponseType(typeof(Coursepost))]
        public IHttpActionResult DeleteCoursepost(long id)
        {
            Coursepost coursepost = db.Courseposts.Find(id);
            if (coursepost == null)
            {
                return NotFound();
            }

            db.Courseposts.Remove(coursepost);
            db.SaveChanges();

            return Ok(coursepost);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursepostExists(long id)
        {
            return db.Courseposts.Count(e => e.id == id) > 0;
        }
    }
}