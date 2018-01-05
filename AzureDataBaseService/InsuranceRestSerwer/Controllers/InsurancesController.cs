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
using InsuranceRestSerwer.Data;
using InsuranceRestSerwer.Models;

namespace InsuranceRestSerwer.Controllers
{
    public class InsurancesController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/Insurances
        public IQueryable<Insurances> GetInsurances()
        {
            return db.Insurances;
        }

        // GET: api/Insurances/5
        [ResponseType(typeof(Insurances))]
        public IHttpActionResult GetInsurances(int id)
        {
            Insurances insurances = db.Insurances.Find(id);
            if (insurances == null)
            {
                return NotFound();
            }

            return Ok(insurances);
        }

        // PUT: api/Insurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInsurances(int id, Insurances insurances)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurances.InsurancesId)
            {
                return BadRequest();
            }

            db.Entry(insurances).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsurancesExists(id))
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

        // POST: api/Insurances
        [ResponseType(typeof(Insurances))]
        public IHttpActionResult PostInsurances(Insurances insurances)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insurances.Add(insurances);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InsurancesExists(insurances.InsurancesId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = insurances.InsurancesId }, insurances);
        }

        // DELETE: api/Insurances/5
        [ResponseType(typeof(Insurances))]
        public IHttpActionResult DeleteInsurances(int id)
        {
            Insurances insurances = db.Insurances.Find(id);
            if (insurances == null)
            {
                return NotFound();
            }

            db.Insurances.Remove(insurances);
            db.SaveChanges();

            return Ok(insurances);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InsurancesExists(int id)
        {
            return db.Insurances.Count(e => e.InsurancesId == id) > 0;
        }
    }
}