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
    public class CarInsuranceApplicationsController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/CarInsuranceApplications
        public IQueryable<CarInsuranceApplication> GetCarInsuranceApplication()
        {
            return db.CarInsuranceApplication;
        }

        // GET: api/CarInsuranceApplications/5
        [ResponseType(typeof(CarInsuranceApplication))]
        public IHttpActionResult GetCarInsuranceApplication(int id)
        {
            CarInsuranceApplication carInsuranceApplication = db.CarInsuranceApplication.Find(id);
            if (carInsuranceApplication == null)
            {
                return NotFound();
            }

            return Ok(carInsuranceApplication);
        }

        // PUT: api/CarInsuranceApplications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarInsuranceApplication(int id, CarInsuranceApplication carInsuranceApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carInsuranceApplication.CarInsuranceApplicationId)
            {
                return BadRequest();
            }

            db.Entry(carInsuranceApplication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarInsuranceApplicationExists(id))
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

        // POST: api/CarInsuranceApplications
        [ResponseType(typeof(CarInsuranceApplication))]
        public IHttpActionResult PostCarInsuranceApplication(CarInsuranceApplication carInsuranceApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarInsuranceApplication.Add(carInsuranceApplication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carInsuranceApplication.CarInsuranceApplicationId }, carInsuranceApplication);
        }

        // DELETE: api/CarInsuranceApplications/5
        [ResponseType(typeof(CarInsuranceApplication))]
        public IHttpActionResult DeleteCarInsuranceApplication(int id)
        {
            CarInsuranceApplication carInsuranceApplication = db.CarInsuranceApplication.Find(id);
            if (carInsuranceApplication == null)
            {
                return NotFound();
            }

            db.CarInsuranceApplication.Remove(carInsuranceApplication);
            db.SaveChanges();

            return Ok(carInsuranceApplication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarInsuranceApplicationExists(int id)
        {
            return db.CarInsuranceApplication.Count(e => e.CarInsuranceApplicationId == id) > 0;
        }
    }
}