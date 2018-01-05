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
    public class RealEstateInsurancesController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/RealEstateInsurances
        public IQueryable<RealEstateInsurance> GetRealEstateInsurance()
        {
            return db.RealEstateInsurance;
        }

        // GET: api/RealEstateInsurances/5
        [ResponseType(typeof(RealEstateInsurance))]
        public IHttpActionResult GetRealEstateInsurance(int id)
        {
            RealEstateInsurance realEstateInsurance = db.RealEstateInsurance.Find(id);
            if (realEstateInsurance == null)
            {
                return NotFound();
            }

            return Ok(realEstateInsurance);
        }

        // PUT: api/RealEstateInsurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRealEstateInsurance(int id, RealEstateInsurance realEstateInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realEstateInsurance.RealEstateInsuranceId)
            {
                return BadRequest();
            }

            db.Entry(realEstateInsurance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateInsuranceExists(id))
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

        // POST: api/RealEstateInsurances
        [ResponseType(typeof(RealEstateInsurance))]
        public IHttpActionResult PostRealEstateInsurance(RealEstateInsurance realEstateInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RealEstateInsurance.Add(realEstateInsurance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = realEstateInsurance.RealEstateInsuranceId }, realEstateInsurance);
        }

        // DELETE: api/RealEstateInsurances/5
        [ResponseType(typeof(RealEstateInsurance))]
        public IHttpActionResult DeleteRealEstateInsurance(int id)
        {
            RealEstateInsurance realEstateInsurance = db.RealEstateInsurance.Find(id);
            if (realEstateInsurance == null)
            {
                return NotFound();
            }

            db.RealEstateInsurance.Remove(realEstateInsurance);
            db.SaveChanges();

            return Ok(realEstateInsurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealEstateInsuranceExists(int id)
        {
            return db.RealEstateInsurance.Count(e => e.RealEstateInsuranceId == id) > 0;
        }
    }
}