using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebApp1.Filters;

namespace WebApp1.Controllers
{
    public class ValuesController : ApiController
    {
        [ApiKeyAuthorization2]
        [WebApiLoggerFilter1]
        [WebApiLoggerFilter2]
        [IosActionFilter]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        [ExceptionLoggerFilter]
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            throw new Exception("mean to throw <<j]'/'/.\\f#*$(&83");
        }

        [ApiKeyAuthorization]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
