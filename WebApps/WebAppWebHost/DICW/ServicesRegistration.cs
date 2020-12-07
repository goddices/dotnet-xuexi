using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Web.Http;
using WebAppWebHost.Core.Services;

namespace WebAppWebHost.DICW
{
    public static class ServicesRegistration
    {
        public static void Register(IWindsorContainer container)
        {
            container.Register(
               Classes.FromThisAssembly()
                .BasedOn<ApiController>()
                    .LifestyleTransient()
            );

            container.Register(
                Component.For<IHelloService>().ImplementedBy<HelloService>()
            );
        }
    }
}