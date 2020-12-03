using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ConsoleAppNetCore.Programs
{
    public class QuartzJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"[{context.FireTimeUtc}] job executed");
            return Task.CompletedTask;
        }
    }
    public static class QuartzCronExpressionClient
    {
        public static void Run()
        {
            Task.Run(async () =>
            {
                var schedulerFactory = new StdSchedulerFactory();
                var _scheduler = await schedulerFactory.GetScheduler();
              

                var job = JobBuilder.Create<QuartzJob>()
                            .WithIdentity("1234")
                            .Build();

                var builder = TriggerBuilder.Create()
                            .WithIdentity("1234")
                            .WithCronSchedule("0/3 * * * * ? ", b =>
                            {
                                // if startAt < now , do nothing about the misfired trigger 
                                b.WithMisfireHandlingInstructionDoNothing();
                                b.InTimeZone(TimeZoneInfo.Local);
                            })
                            .EndAt(DateTimeOffset.MaxValue)
                            //.StartAt(startAt.Value)
                            //.StartNow()
                            .StartAt(DateTimeOffset.UtcNow.AddSeconds(-20))
                            ;

                var trigger = builder.Build(); 
                await _scheduler.Start();
                await _scheduler.ScheduleJob(job, trigger);
            });
            Console.ReadLine();

            CronExpression aa = new CronExpression("0 0 0 * 1,3 ?");
            Console.WriteLine(aa.CronExpressionString);


            string cronTest = "* 40 10/2 * * ?";
            Console.WriteLine(CronExpression.IsValidExpression(cronTest));

            string cronExpressionInBeijingTime = "* 40 10/2 * * ?";
            CronExpression cronExpression = new CronExpression(cronExpressionInBeijingTime);
            cronExpression.TimeZone = TimeZoneInfo.Local;

            DateTimeOffset? nextUtcTime = cronExpression.GetNextValidTimeAfter(DateTimeOffset.UtcNow);
            DateTimeOffset nextLocalTime = TimeZoneInfo.ConvertTime(nextUtcTime.Value, TimeZoneInfo.Local);



            Console.WriteLine(cronExpressionInBeijingTime);


            Console.WriteLine(nextUtcTime);
            Console.WriteLine(nextLocalTime);

            CronExpression utcExpression = new CronExpression(cronExpressionInBeijingTime);

            var summ = utcExpression.GetExpressionSummary();
            //  cronExpression.TimeZone = TimeZoneInfo.Utc;
            Console.WriteLine(cronExpression.CronExpressionString);



            string cor = "36 24 15 L /1 ?";
            CronExpression exer = new CronExpression(cor);
            DateTimeOffset? af = DateTimeOffset.Now;
            for (int i = 0; i < 5; i++)
            {
                af = exer.GetNextValidTimeAfter(af.Value);
                Console.WriteLine(af);
            }

        }
    }
}
