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
    public class TravelInsurancesController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/TravelInsurances
        public IQueryable<TravelInsurance> GetTravelInsurance()
        {
            return db.TravelInsurance;
        }

        // GET: api/TravelInsurances/5
        [ResponseType(typeof(TravelInsurance))]
        public IHttpActionResult GetTravelInsurance(int id)
        {
            TravelInsurance travelInsurance = db.TravelInsurance.Find(id);
            if (travelInsurance == null)
            {
                return NotFound();
            }

            return Ok(travelInsurance);
        }

        // PUT: api/TravelInsurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTravelInsurance(int id, TravelInsurance travelInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != travelInsurance.TravelInsuranceId)
            {
                return BadRequest();
            }

            db.Entry(travelInsurance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelInsuranceExists(id))
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

        // POST: api/TravelInsurances
        [ResponseType(typeof(TravelInsurance))]
        public IHttpActionResult PostTravelInsurance(TravelInsurance travelInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TravelInsurance.Add(travelInsurance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = travelInsurance.TravelInsuranceId }, travelInsurance);
        }

        // DELETE: api/TravelInsurances/5
        [ResponseType(typeof(TravelInsurance))]
        public IHttpActionResult DeleteTravelInsurance(int id)
        {
            TravelInsurance travelInsurance = db.TravelInsurance.Find(id);
            if (travelInsurance == null)
            {
                return NotFound();
            }

            db.TravelInsurance.Remove(travelInsurance);
            db.SaveChanges();

            return Ok(travelInsurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravelInsuranceExists(int id)
        {
            return db.TravelInsurance.Count(e => e.TravelInsuranceId == id) > 0;
        }
    }
}