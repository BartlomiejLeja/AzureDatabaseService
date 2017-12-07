using InsuranceRestSerwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace InsuranceRestSerwer.Controllers
{
    public class UserController : ApiController
    {
        SqlHelper sqlHelper = new SqlHelper();
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "User1", "User2" };
        }

        // GET: api/User/5
        public Client Get(int id)
        {
            return sqlHelper.getUser(id);
        }

        // POST: api/User
        public void Post([FromBody] Client value)
        {
            sqlHelper.saveUser(value);
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
