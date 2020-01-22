using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppAspNetCore.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMyServiceSingleton _myService;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            // _myService = myService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {


            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {Time}", DateTime.Now);
                IMyService myService;
                //BackgroundService 是一个单例(singleton)，所以要用Scoped服务的时候要这样
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    myService = scope.ServiceProvider.GetRequiredService<IMyService>();
                    Print("Scoped ", _logger, myService);
                }
                //Print("Singleton ", _logger, _myService);
                await Task.Delay(1000);
            }
        }

        private static void Print(string prefix, ILogger<Worker> logger, IMyService myService)
        {
            var values = myService.GetValues();
            logger.LogInformation(prefix + string.Join(',', values));
            logger.LogInformation(prefix + "IMyService instance hash code = {0}", myService.GetHashCode());
        }

        private static void Print(string prefix, ILogger<Worker> logger, IMyServiceSingleton myService)
        {
            var values = myService.GetValues();
            logger.LogInformation(prefix + string.Join(',', values));
            logger.LogInformation(prefix + "IMyService instance hash code = {0}", myService.GetHashCode());
        }
    }
}
