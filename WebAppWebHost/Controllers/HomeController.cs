using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppWebHost.Filters;

namespace WebAppWebHost.Controllers
{
    public class HomeController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("--*-*-*-*-*-action executed-*-*-*-*-*-*-*-*", "Debug");
            base.OnActionExecuted(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("--*-*-*-*-*-action executing-*-*-*-*-*-*-*-*", "Debug");
            base.OnActionExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine("--*-*-*-*-*-result executed-*-*-*-*-*-*-*-*", "Debug");
            base.OnResultExecuted(filterContext);
        }
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debug.WriteLine("--*-*-*-*-*-result executing-*-*-*-*-*-*-*-*", "Debug");
            base.OnResultExecuting(filterContext);
        }

        [MvcLogger1(Order = 3)]
        [MvcLogger2(Order = 2)]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
