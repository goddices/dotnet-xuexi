using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDbFirst.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAppAspNetCore.Services;
using WebAppAspNetCore.Settings;

namespace WebAppAspNetCore
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<SqlearnContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("db"));
            });
            services.AddScoped<IMyService, MyService>();
            services.Configure<MySettings>(Configuration.GetSection("MySettings"));


            services.Configure<SlackApiSettings>("Dev", Configuration.GetSection("SlackApi:DevChannel"));
            services.Configure<SlackApiSettings>("General", Configuration.GetSection("SlackApi:GeneralChannel"));
            services.Configure<SlackApiSettings>("Public", Configuration.GetSection("SlackApi:PublicChannel"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
