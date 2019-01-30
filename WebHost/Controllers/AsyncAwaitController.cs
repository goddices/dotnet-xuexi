using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebHost.Controllers
{
    public class AsyncAwaitController : ApiController
    {
        // GET api/<controller>
        public async Task<IEnumerable<string>> Get()
        {
            string requestId ="request id "+ Guid.NewGuid().ToString();
            string actionThreadId = "action thread id "+ Thread.CurrentThread.ManagedThreadId.ToString();
            string taskThreadId ="task thread id "+ await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return Thread.CurrentThread.ManagedThreadId.ToString();
            });
            return new string[] { requestId, actionThreadId, taskThreadId };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}