using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ConsoleAppNetCore.Programs;

namespace ConsoleAppNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine($"Current SynchronizationContext is {SynchronizationContext.Current?.ToString()}");

            //AutoMapperClient.Run();
            //TimeZoneInfoClient.Run();
            //EmbeddedResourceClient.Run();
            QuartzCronExpressionClient.Run();

            Console.ReadLine();
        }


    }
}
