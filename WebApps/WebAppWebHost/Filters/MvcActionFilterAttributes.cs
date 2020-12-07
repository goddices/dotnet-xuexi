using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppWebHost.Filters
{
    public class MvcLogger1Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("Mvc Filter 1111111 OnActionExecuting", "Debug");
            base.OnActionExecuting(filterContext);
        }
    }

    public class MvcLogger2Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("Mvc Filter 2222222 OnActionExecuting", "Debug");
            base.OnActionExecuting(filterContext);
        }
    }
}