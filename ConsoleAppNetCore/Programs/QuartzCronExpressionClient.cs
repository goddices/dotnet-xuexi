using System;
using System.Collections.Generic;
using System.Text;
using Quartz;

namespace ConsoleAppNetCore.Programs
{
    public static class QuartzCronExpressionClient
    {
        public static void Run()
        {

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
