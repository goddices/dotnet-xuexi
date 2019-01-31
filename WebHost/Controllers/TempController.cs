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
            public int ActionThreadId { get; set; }
            public int TaskThreadId { get; set; }
        }
        public async Task<RequestInfo> Get()
        {
            RequestInfo ri = new RequestInfo
            {
                ActionThreadId = Thread.CurrentThread.ManagedThreadId,
                RequestId = Guid.NewGuid().ToString()
            };

            //
            await Task.Run(() =>
            {
                Thread.Sleep(2000); ri.TaskThreadId = Thread.CurrentThread.ManagedThreadId;
            });
            Thread.Sleep(4000);
            return ri;
        }
    }
}
