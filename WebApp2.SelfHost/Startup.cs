﻿using Owin;
using System.Web.Http;

namespace WebApp2
{
    /// <summary>
    /// Self-Host
    /// https://docs.microsoft.com/zh-cn/aspnet/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api
    /// </summary>
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
