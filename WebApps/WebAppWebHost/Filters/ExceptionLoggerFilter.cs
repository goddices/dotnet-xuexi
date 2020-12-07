using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace WebAppWebHost.Filters
{
    public class ExceptionLoggerFilter : Attribute, IExceptionFilter
    {
        public bool AllowMultiple => true;

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Debug.WriteLine("---------------------------------------------------");
                Debug.WriteLine(actionExecutedContext.Exception.ToString());
                Debug.WriteLine("---------------------------------------------------");
            });
        }
    }
}