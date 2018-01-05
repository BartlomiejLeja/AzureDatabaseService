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
    public class CarInsurancesController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/CarInsurances
        public IQueryable<CarInsurance> GetCarInsurance()
        {
            return db.CarInsurance;
        }

        // GET: api/CarInsurances/5
        [ResponseType(typeof(CarInsurance))]
        public IHttpActionResult GetCarInsurance(int id)
        {
            CarInsurance carInsurance = db.CarInsurance.Find(id);
            if (carInsurance == null)
            {
                return NotFound();
            }

            return Ok(carInsurance);
        }

        // PUT: api/CarInsurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarInsurance(int id, CarInsurance carInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carInsurance.CarInsuranceId)
            {
                return BadRequest();
            }

            db.Entry(carInsurance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarInsuranceExists(id))
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

        // POST: api/CarInsurances
        [ResponseType(typeof(CarInsurance))]
        public IHttpActionResult PostCarInsurance(CarInsurance carInsurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarInsurance.Add(carInsurance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carInsurance.CarInsuranceId }, carInsurance);
        }

        // DELETE: api/CarInsurances/5
        [ResponseType(typeof(CarInsurance))]
        public IHttpActionResult DeleteCarInsurance(int id)
        {
            CarInsurance carInsurance = db.CarInsurance.Find(id);
            if (carInsurance == null)
            {
                return NotFound();
            }

            db.CarInsurance.Remove(carInsurance);
            db.SaveChanges();

            return Ok(carInsurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarInsuranceExists(int id)
        {
            return db.CarInsurance.Count(e => e.CarInsuranceId == id) > 0;
        }
    }
}