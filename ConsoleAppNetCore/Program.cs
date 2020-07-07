using System;
using System.Collections.Generic;
using ConsoleAppNetCore.Programs;

namespace ConsoleAppNetCore
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
            //Console.WriteLine($"Current SynchronizationContext is {SynchronizationContext.Current?.ToString()}");

            //AutoMapperClient.Run();
            //TimeZoneInfoClient.Run();
            //EmbeddedResourceClient.Run();
            //QuartzCronExpressionClient.Run();
            RsaSignClient.Run();

            Console.ReadLine();
        }
    }
}
