using System;
using System.Collections.Generic;
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
    public class IosActionFilterAttribute : Attribute, IActionFilter
    {
        public bool AllowMultiple => true;

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext,
            CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            if (!actionContext.Request.Headers.UserAgent.ToString().ToLower().Contains("ios"))
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            return await continuation?.Invoke();
        }
    }
}