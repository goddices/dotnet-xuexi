using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebHost.Controllers
{
    public class ValuesController : ApiController
    {
        private static int TId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }

        // GET api/<controller>
        public async Task<IEnumerable<string>> Get()
        {
            Debug.WriteLine($"thread id {TId()} before Task.Run", "Debug");
            await Task.Run(() =>
            {
                Debug.WriteLine($"thread id {TId()} in Task.Run", "Debug");

            });
            Debug.WriteLine($"thread id {TId()} after Task.Run", "Debug");
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            Debug.WriteLine($"thread id {TId()} before Task.Run", "Debug");
            Task.Run(() =>
            {
                Debug.WriteLine($"thread id {TId()} in Task.Run", "Debug");

            });
            Debug.WriteLine($"thread id {TId()} after Task.Run", "Debug");

            return "value";
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody]String value)
        {
            Debug.WriteLine($"thread id {TId()}", "Debug");

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(value);
            return response;
            //return Task.FromResult("value");
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