using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace WebAppWebHost.DI
{
    /// <summary>
    /// webapi 依赖注入
    /// https://docs.microsoft.com/zh-cn/aspnet/web-api/overview/advanced/dependency-injection
    /// </summary>
    public class CastleWindsorResolver : IDependencyResolver
    {
        private IWindsorContainer container;
        public CastleWindsorResolver(IWindsorContainer container)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
        }


        public object GetService(Type serviceType)
        {
            Debug.WriteLine("GetService: " + serviceType.Name, "Debug");
            try
            {
                return container.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            Debug.WriteLine("GetServices: " + serviceType.Name, "Debug");
            try
            {
                Array arr = container.ResolveAll(serviceType);
                return (IEnumerable<object>)arr;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString(), "Debug");
                return new List<object>();
            }
        }


        public IDependencyScope BeginScope()
        {
            return new CastleWindsorResolver(container);
        }


        public void Dispose()
        {
            Dispose(true);
        }


        protected virtual void Dispose(bool disposing)
        {
            container.Dispose();
        }
    }
}