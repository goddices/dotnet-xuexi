using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAppWebHost.DI;
using WebAppWebHost.DICW;
using WebAppWebHost.Filters;
using WebAppWebHost.MessageHandlers;

namespace WebAppWebHost
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            var container = new Castle.Windsor.WindsorContainer();
            ServicesRegistration.Register(container);
            config.DependencyResolver = new CastleWindsorResolver(container);

            // 注册MessageHandler，作用全局。
            config.MessageHandlers.Add(new MyGlobalMessageHandler());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/MethodOverride/{id}",
                defaults: new { controller = "MethodOverride", id = RouteParameter.Optional },
                constraints: null,
                handler: new MethodOverrideHandler(config)
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

             
            config.Filters.Add(new GlobalEffectFilterAttribute());
        }
    }
}
