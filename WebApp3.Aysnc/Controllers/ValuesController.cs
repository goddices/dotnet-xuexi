using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApp3.Controllers
{
    public class ValuesController : ApiController
    {
        private static int TId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {

            //System.Web.AspNetSynchronizationContext
            Debug.WriteLine($"Current SynchronizationContext is {SynchronizationContext.Current?.ToString()}");
            base.Initialize(controllerContext);
        }

        // GET api/<controller>
        public async Task<IEnumerable<string>> Get()
        {
            try
            {
                Debug.WriteLine($"thread id {TId()} before Task.Run", "Async Debug");
                IEnumerable<string> result = await Task.Run(() =>
                 {
                     Thread.Sleep(2000);
                     Debug.WriteLine($"thread id {TId()} in Task.Run", "Async Debug");
                     return new string[] { "value1", "value2" };
                 });
                Debug.WriteLine($"thread id {TId()} after Task.Run", "Async Debug");
                return result;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception:" + e.ToString(), "Async Debug");
            }
            return new string[0];
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            try
            {
                Debug.WriteLine($"thread id {TId()} before Task.Run", "Task Debug");
                Task.Run(() =>
                {
                    Debug.WriteLine($"thread id {TId()} in Task.Run", "Task Debug");

                });
                Debug.WriteLine($"thread id {TId()} after Task.Run", "Task Debug");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception:" + e.ToString(), "Task Debug");
            }
            return id.ToString();
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody]String value)
        {
            Debug.WriteLine($"thread id {TId()}", "Post Debug");

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