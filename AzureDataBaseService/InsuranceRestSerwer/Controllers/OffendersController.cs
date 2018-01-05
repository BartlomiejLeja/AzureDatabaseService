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
    public class OffendersController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/Offenders
        public IQueryable<Offenders> GetOffenders()
        {
            return db.Offenders;
        }

        // GET: api/Offenders/5
        [ResponseType(typeof(Offenders))]
        public IHttpActionResult GetOffenders(int id)
        {
            Offenders offenders = db.Offenders.Find(id);
            if (offenders == null)
            {
                return NotFound();
            }

            return Ok(offenders);
        }

        // PUT: api/Offenders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOffenders(int id, Offenders offenders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != offenders.OffendersId)
            {
                return BadRequest();
            }

            db.Entry(offenders).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffendersExists(id))
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

        // POST: api/Offenders
        [ResponseType(typeof(Offenders))]
        public IHttpActionResult PostOffenders(Offenders offenders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Offenders.Add(offenders);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OffendersExists(offenders.OffendersId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = offenders.OffendersId }, offenders);
        }

        // DELETE: api/Offenders/5
        [ResponseType(typeof(Offenders))]
        public IHttpActionResult DeleteOffenders(int id)
        {
            Offenders offenders = db.Offenders.Find(id);
            if (offenders == null)
            {
                return NotFound();
            }

            db.Offenders.Remove(offenders);
            db.SaveChanges();

            return Ok(offenders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OffendersExists(int id)
        {
            return db.Offenders.Count(e => e.OffendersId == id) > 0;
        }
    }
}