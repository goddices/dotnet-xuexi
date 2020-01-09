using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppAspNetFramework.Controllers
{
    /// <summary>
    /// async关键字在webapp
    /// </summary> 
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncController : ControllerBase
    {
        private static int TId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }


        /// <summary>
        /// GetAsync
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAsync")]
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

        /// <summary>
        /// GetSync
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSync")]
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


        /// <summary>
        /// GetHttpContextAsync
        /// </summary>
        /// <returns></returns>
        [Route("GetHttpContextAsync")]
        public async Task GetHttpContextAsync()
        {
            var ctx = HttpContext;
            await Task.Run(() =>
            {
                //get null
                var nullctx = HttpContext;

            });
        }
    }
}