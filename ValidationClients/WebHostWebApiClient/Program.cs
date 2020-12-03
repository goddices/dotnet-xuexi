using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Configuration;

namespace WebHostWebApiClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = CreateHostBuilder(args).Build();


            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void InitLogConfig(string serviceName, string environment)
        {
            var loggerConfig = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                // Filter out ASP.NET Core infrastructre logs that are Information and below
                .MinimumLevel.Override("Microsoft.AspNetCore.SignalR", LogEventLevel.Debug)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()


                .WriteTo.Async(c => c.File(
                    "./logs/log.log",
                    outputTemplate: "[[{LogType}]] [{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level:w3}] [{Environment}] [{ServiceName}] [{ETraceId}] {Message:lj} {Exception}{NewLine}",
                    shared: true, //   Allow the log file to be shared by multiple processes. The default is false.
                    rollOnFileSizeLimit: true,
                    retainedFileCountLimit: 5, //  The maximum number of log files that will be retained
                    rollingInterval: RollingInterval.Infinite));
            Log.Logger = loggerConfig.CreateLogger();
        }




    }

}
