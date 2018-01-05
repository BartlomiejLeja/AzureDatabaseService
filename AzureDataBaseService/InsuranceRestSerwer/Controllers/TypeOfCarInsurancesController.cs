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
using InsuranceRestSerwer.Models.CarInsurances;

namespace InsuranceRestSerwer.Controllers
{
    public class TypeOfCarInsurancesController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/TypeOfCarInsurances
        public IQueryable<TypeOfCarInsurance> GetTypeOfCarInsurance()
        {
            return db.TypeOfCarInsurance;
        }

        // GET: api/TypeOfCarInsurances/5
        [ResponseType(typeof(TypeOfCarInsurance))]
        public IHttpActionResult GetTypeOfCarInsurance(int id)
        {
            TypeOfCarInsurance typeOfCarInsurance = db.TypeOfCarInsurance.Find(id);
            if (typeOfCarInsurance == null)
            {
                return NotFound();
            }

            return Ok(typeOfCarInsurance);
        }

        // PUT: api/TypeOfCarInsurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeOfCarInsurance(int id, TypeOfCarInsurance typeOfCarInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeOfCarInsurance.TypeOfCarInsuranceId)
            {
                return BadRequest();
            }

            db.Entry(typeOfCarInsurance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfCarInsuranceExists(id))
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

        // POST: api/TypeOfCarInsurances
        [ResponseType(typeof(TypeOfCarInsurance))]
        public IHttpActionResult PostTypeOfCarInsurance(TypeOfCarInsurance typeOfCarInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeOfCarInsurance.Add(typeOfCarInsurance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TypeOfCarInsuranceExists(typeOfCarInsurance.TypeOfCarInsuranceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = typeOfCarInsurance.TypeOfCarInsuranceId }, typeOfCarInsurance);
        }

        // DELETE: api/TypeOfCarInsurances/5
        [ResponseType(typeof(TypeOfCarInsurance))]
        public IHttpActionResult DeleteTypeOfCarInsurance(int id)
        {
            TypeOfCarInsurance typeOfCarInsurance = db.TypeOfCarInsurance.Find(id);
            if (typeOfCarInsurance == null)
            {
                return NotFound();
            }

            db.TypeOfCarInsurance.Remove(typeOfCarInsurance);
            db.SaveChanges();

            return Ok(typeOfCarInsurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeOfCarInsuranceExists(int id)
        {
            return db.TypeOfCarInsurance.Count(e => e.TypeOfCarInsuranceId == id) > 0;
        }
    }
}