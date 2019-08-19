using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace WebApp1.MessageHandlers
{
    /// <summary>
    /// https://docs.microsoft.com/zh-cn/aspnet/web-api/overview/advanced/http-message-handlers
    /// 
    /// 
    /// 请注意，MessageHandler2替换的默认值HttpControllerDispatcher。 
    /// 在此示例中，MessageHandler2创建响应，并的匹配"Route2"永远不会转到控制器的请求。 
    /// 这使您的整个 Web API 控制器机制替换为你自己的自定义终结点
    /// 或者，可以每个路由消息处理程序委托给HttpControllerDispatcher，后者随后将调度到的控制器。
    /// </summary>
    public class MethodOverrideHandler : DelegatingHandler
    {
        readonly string[] _methods = { "DELETE", "HEAD", "PUT" };
        const string _header = "X-HTTP-Method-Override";
        public MethodOverrideHandler(HttpConfiguration httpConfiguration)
        {
            //request 顺序: 客户端发起请求 -> HttpServer -> DelegatingHandler -> HttpRoutingDispatcher
            // -> HttpControllerDispatcher -> Controller

            InnerHandler = new HttpControllerDispatcher(httpConfiguration);
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Method Override DelegatingHandler : " + request.RequestUri.ToString(), "Debug");
            
            // Check for HTTP POST with the X-HTTP-Method-Override header.
            if (request.Method == HttpMethod.Post && request.Headers.Contains(_header))
            {
                // Check if the header value is in our methods list.
                var method = request.Headers.GetValues(_header).FirstOrDefault();
                if (_methods.Contains(method, StringComparer.InvariantCultureIgnoreCase))
                {
                    // Change the request method.
                    request.Method = new HttpMethod(method);
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
