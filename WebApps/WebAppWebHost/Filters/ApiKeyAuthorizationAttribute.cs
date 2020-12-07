using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace WebAppWebHost.Filters
{
    public class ApiKeyAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple => true;

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext,
            CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            HttpHeaders headers = actionContext.Request.Headers;
            if (headers.Contains("apikey"))
            {
                if (headers.GetValues("apikey").Contains("apivalue"))
                {
                    return await continuation?.Invoke();
                }
            }
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }

    public class ApiKeyAuthorization2Attribute : AuthorizationFilterAttribute
    {
        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            HttpHeaders headers = actionContext.Request.Headers;
            if (headers.Contains("apikey"))
            {
                if (headers.GetValues("apikey").Contains("apivalue"))
                {
                    await base.OnAuthorizationAsync(actionContext, cancellationToken);
                    return;
                }
            }
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
        }
    }
}