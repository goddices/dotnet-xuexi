using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApp1.Filters
{
    public class GlobalEffectFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch stopWatch;
        public GlobalEffectFilterAttribute() : base()
        {
            Debug.WriteLine("GlobalEffectFilterAttribute Constructure", "Debug");
            stopWatch = new Stopwatch();
        }
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            stopWatch.Reset();
            stopWatch.Start();
            //Debug.WriteLine(actionContext.Request.RequestUri.ToString(), "Debug");
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            stopWatch.Stop();

            Debug.WriteLine(actionExecutedContext.Request.RequestUri.ToString() + 
                " executed " + stopWatch.Elapsed.TotalSeconds + "seconds", "Debug");
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }
}