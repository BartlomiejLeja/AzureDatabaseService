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
    public class ClientDatasController : ApiController
    {
        private InsuranceContex db = new InsuranceContex();

        // GET: api/ClientDatas
        public IQueryable<ClientData> GetClientDatas()
        {
            return db.ClientDatas;
        }

        // GET: api/ClientDatas/5
        [ResponseType(typeof(ClientData))]
        public IHttpActionResult GetClientData(int id)
        {
            ClientData clientData = db.ClientDatas.Find(id);
            if (clientData == null)
            {
                return NotFound();
            }

            return Ok(clientData);
        }

        // PUT: api/ClientDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientData(int id, ClientData clientData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientData.ClientDataId)
            {
                return BadRequest();
            }

            db.Entry(clientData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientDataExists(id))
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

        // POST: api/ClientDatas
        [ResponseType(typeof(ClientData))]
        public IHttpActionResult PostClientData(ClientData clientData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientDatas.Add(clientData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClientDataExists(clientData.ClientDataId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clientData.ClientDataId }, clientData);
        }

        // DELETE: api/ClientDatas/5
        [ResponseType(typeof(ClientData))]
        public IHttpActionResult DeleteClientData(int id)
        {
            ClientData clientData = db.ClientDatas.Find(id);
            if (clientData == null)
            {
                return NotFound();
            }

            db.ClientDatas.Remove(clientData);
            db.SaveChanges();

            return Ok(clientData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientDataExists(int id)
        {
            return db.ClientDatas.Count(e => e.ClientDataId == id) > 0;
        }
    }
}