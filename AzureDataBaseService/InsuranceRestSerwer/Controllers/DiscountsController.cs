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
    public class DiscountsController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/Discounts
        public IQueryable<Discount> GetDiscount()
        {
            return db.Discount;
        }

        // GET: api/Discounts/5
        [ResponseType(typeof(Discount))]
        public IHttpActionResult GetDiscount(int id)
        {
            Discount discount = db.Discount.Find(id);
            if (discount == null)
            {
                return NotFound();
            }

            return Ok(discount);
        }

        // PUT: api/Discounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiscount(int id, Discount discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discount.DiscountId)
            {
                return BadRequest();
            }

            db.Entry(discount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountExists(id))
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

        // POST: api/Discounts
        [ResponseType(typeof(Discount))]
        public IHttpActionResult PostDiscount(Discount discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Discount.Add(discount);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DiscountExists(discount.DiscountId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = discount.DiscountId }, discount);
        }

        // DELETE: api/Discounts/5
        [ResponseType(typeof(Discount))]
        public IHttpActionResult DeleteDiscount(int id)
        {
            Discount discount = db.Discount.Find(id);
            if (discount == null)
            {
                return NotFound();
            }

            db.Discount.Remove(discount);
            db.SaveChanges();

            return Ok(discount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiscountExists(int id)
        {
            return db.Discount.Count(e => e.DiscountId == id) > 0;
        }
    }
}