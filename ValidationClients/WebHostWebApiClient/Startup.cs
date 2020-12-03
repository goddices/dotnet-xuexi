using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Logging;
using Microsoft.Extensions.Logging;
using Polly;

namespace WebHostWebApiClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var builder = services.AddHttpClient("storage", client =>
            {
                client.BaseAddress = new Uri("http://192.168.133.130:8089");
            });
            //builder.AddHttpMessageHandler<LoggingHttpMessageHandler>();
            builder.AddTransientHttpErrorPolicy(b => b.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1)));
            //builder.AddTypedClient(c => RestService.For<IStorageServiceClient>(c));
            services.AddScoped<IStorageServiceClient, StorageServiceClient>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
