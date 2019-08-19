using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApp1.MessageHandlers
{
    /// <summary>
    /// 另一种横切模式，类似HttpModule和Filter。注意不同于HttpHandler。
    /// https://docs.microsoft.com/zh-cn/aspnet/web-api/overview/advanced/http-message-handlers 
    /// </summary>
    public class MyGlobalMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Global DelegatingHandler : " + request.RequestUri.ToString(), "Debug");
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            response.Headers.Add("X-Custom-Header", "This is my custom header.");
            return response;
        }
    }
}