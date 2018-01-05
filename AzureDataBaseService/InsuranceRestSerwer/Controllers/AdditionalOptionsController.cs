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
using InsuranceRestSerwer.Models.TravelInsurances;

namespace InsuranceRestSerwer.Controllers
{
    public class AdditionalOptionsController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/AdditionalOptions
        public IQueryable<AdditionalOptions> GetAdditionalOptions()
        {
            return db.AdditionalOptions;
        }

        // GET: api/AdditionalOptions/5
        [ResponseType(typeof(AdditionalOptions))]
        public IHttpActionResult GetAdditionalOptions(int id)
        {
            AdditionalOptions additionalOptions = db.AdditionalOptions.Find(id);
            if (additionalOptions == null)
            {
                return NotFound();
            }

            return Ok(additionalOptions);
        }

        // PUT: api/AdditionalOptions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdditionalOptions(int id, AdditionalOptions additionalOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != additionalOptions.AdditionalOptionsId)
            {
                return BadRequest();
            }

            db.Entry(additionalOptions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditionalOptionsExists(id))
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

        // POST: api/AdditionalOptions
        [ResponseType(typeof(AdditionalOptions))]
        public IHttpActionResult PostAdditionalOptions(AdditionalOptions additionalOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdditionalOptions.Add(additionalOptions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = additionalOptions.AdditionalOptionsId }, additionalOptions);
        }

        // DELETE: api/AdditionalOptions/5
        [ResponseType(typeof(AdditionalOptions))]
        public IHttpActionResult DeleteAdditionalOptions(int id)
        {
            AdditionalOptions additionalOptions = db.AdditionalOptions.Find(id);
            if (additionalOptions == null)
            {
                return NotFound();
            }

            db.AdditionalOptions.Remove(additionalOptions);
            db.SaveChanges();

            return Ok(additionalOptions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdditionalOptionsExists(int id)
        {
            return db.AdditionalOptions.Count(e => e.AdditionalOptionsId == id) > 0;
        }
    }
}