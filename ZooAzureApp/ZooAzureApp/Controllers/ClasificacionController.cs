using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooAzureApp.Controllers
{
    public class ClasificacionController : ApiController
    {
        // GET: api/Clasificacion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Clasificacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clasificacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clasificacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clasificacion/5
        public void Delete(int id)
        {
        }
    }
}
