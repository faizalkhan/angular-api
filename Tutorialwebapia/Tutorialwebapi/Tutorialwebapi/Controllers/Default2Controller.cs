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
    public class Default2Controller : ApiController
    {
        private Dbmodels db = new Dbmodels();

        // GET api/Default2
        public IQueryable<Employeemaster> GetEmployeemasters()
        {
            return db.Employeemasters;
        }

        // GET api/Default2/5
        [ResponseType(typeof(Employeemaster))]
        public IHttpActionResult GetEmployeemaster(long id)
        {
            Employeemaster employeemaster = db.Employeemasters.Find(id);
            if (employeemaster == null)
            {
                return NotFound();
            }

            return Ok(employeemaster);
        }

        // PUT api/Default2/5
        public IHttpActionResult PutEmployeemaster(long id, Employeemaster employeemaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeemaster.Id)
            {
                return BadRequest();
            }

            db.Entry(employeemaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeemasterExists(id))
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

        // POST api/Default2
        [ResponseType(typeof(Employeemaster))]
        public IHttpActionResult PostEmployeemaster(Employeemaster employeemaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employeemasters.Add(employeemaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeemasterExists(employeemaster.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employeemaster.Id }, employeemaster);
        }

        // DELETE api/Default2/5
        [ResponseType(typeof(Employeemaster))]
        public IHttpActionResult DeleteEmployeemaster(long id)
        {
            Employeemaster employeemaster = db.Employeemasters.Find(id);
            if (employeemaster == null)
            {
                return NotFound();
            }

            db.Employeemasters.Remove(employeemaster);
            db.SaveChanges();

            return Ok(employeemaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeemasterExists(long id)
        {
            return db.Employeemasters.Count(e => e.Id == id) > 0;
        }
    }
}