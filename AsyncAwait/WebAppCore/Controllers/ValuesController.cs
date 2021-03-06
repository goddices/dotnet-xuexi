﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public async Task<string> Get()
        {
            StringBuilder re = new StringBuilder();
            re.Append("before await tid:").Append(Thread.CurrentThread.ManagedThreadId).Append("\r\n");
            await Task.Delay(10);
            re.Append("after await tid:").Append(Thread.CurrentThread.ManagedThreadId);
            return re.ToString();
        }


        [Route("~/api/values/get2")]
        public async Task<List<string>> Get2()
        {
            List<string> result = new List<string>();
            var jobs = new Task[5];
            var rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                jobs[i] = GetDataAsync(result, rand.Next().ToString());
            }
            await Task.WhenAll(jobs);
            return result;
        }

        private async Task GetDataAsync(List<string> result, string number)
        {
            await Task.Delay(10);
            result.Add(number);
        }
    }
}
