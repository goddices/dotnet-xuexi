using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebAppAspNetFramework.Controllers
{ 

    public class AsyncController : ApiController
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
        [HttpGet]
        [Route("~/api/Async/GetAsync")]
        public async Task<string> GetAsync()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append($"thread id {TId()} before await Task \r\n");
                await Task.Delay(2000);
                sb.Append($"thread id {TId()} after await Task \r\n");
            }
            catch (Exception e)
            {
                sb.Append("Exception:" + e.ToString());
            }
            return sb.ToString();

            /* 
             * return case 1
             *   thread id x before await Task
             *   thread id y after await Task
             *   
             * return case 2
             *   thread id x before await Task
             *   thread id x after await Task
             */
        }

        // GET api/<controller>/5 
        [HttpGet]
        [Route("~/api/Async/GetSync")]
        public string GetSync()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append($"thread id {TId()} before Thread.Sleep \r\n");
                Thread.Sleep(2000);
                sb.Append($"thread id {TId()} after Thread.Sleep \r\n");
            }
            catch (Exception e)
            {
                sb.Append("Exception:" + e.ToString());
            }
            return sb.ToString();

            /* 
             * return case
             *   thread id x before Thread.Sleep
             *   thread id x after Thread.Sleep
             */
        }


        [HttpGet]
        [Route("GetHttpContextAsync")]
        public async Task GetHttpContextAsync()
        {
            var ctx = HttpContext.Current;
            await Task.Run(() =>
            {
                //get null
                var nullctx = HttpContext.Current;

            });
        }

    }
}