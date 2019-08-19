using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApp1.Filters
{
    public class WebApiLoggerFilter1Attribute : Attribute, IActionFilter
    {
        public bool AllowMultiple => true;

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Debug.WriteLine("WebApi Filter 111111", "Debug"); 
            return await continuation?.Invoke();
        }
    }

    public class WebApiLoggerFilter2Attribute : ActionFilterAttribute
    {
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Debug.WriteLine("WebApi Filter 222222", "Debug");
            });

            //return Task.FromResult(); actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            //return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }

    
}