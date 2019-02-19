using Newtonsoft.Json;
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
    public class TempController : ApiController
    {
        public struct RequestInfo
        {

            public string RequestId { get; set; }
            [JsonProperty("ThreadId_1_ActionExecuting")]
            public int ActionExecutingThreadId { get; set; }
            [JsonProperty("ThreadId_2_TaskExecting")]
            public int TaskThreadId { get; set; }
            [JsonProperty("ThreadId_3_ActionExecuting")]
            public int ActionExecutedThreadId { get; set; }
        }

        public async Task Test()
         {
            var task = Get();
            var result = task.IsCompleted ? task.Result : await task;

        }
        public async Task<RequestInfo> Get()
        {
            RequestInfo ri = new RequestInfo
            {
                ActionExecutingThreadId = Thread.CurrentThread.ManagedThreadId,
                RequestId = Guid.NewGuid().ToString()
            };
            await Task.Run(() =>
            {
                Task.Delay(1000);
                ri.TaskThreadId = Thread.CurrentThread.ManagedThreadId;
            });

            ri.ActionExecutedThreadId = Thread.CurrentThread.ManagedThreadId;
            return ri;
        }
    }
}
