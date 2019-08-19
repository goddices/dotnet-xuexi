using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //注册路由时，还要忽略自定义的HttpHandler，这里是MyHandler，在Web.config中：
            //<system.webServer>
            //  <handlers>
            //    <add name="MyHandler" path="*.mhd" verb="*" type="WebApp1.Handlers.MyHandler" />
            //  </handlers>
            //</system.webServer>
            routes.IgnoreRoute("{resource}.mhd");
            ////////////////////////////////////

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
