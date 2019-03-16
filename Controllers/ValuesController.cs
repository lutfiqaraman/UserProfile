using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserProfileAPIDemo.DAL;
using UserProfileAPIDemo.Models;

namespace UserProfileAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {
        private UserProfileContext db = new UserProfileContext();

        // GET api/values
        public IEnumerable<UserProfile> Get()
        {
            return db.UserProfile.ToList();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
