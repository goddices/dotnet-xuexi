using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            QuartzCronExpressionClient.Run();
            //RsaSignClient.Run();
            var result = AsyncMethods.CallMethodAsync("async/await").GetAwaiter().GetResult();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

    internal static class AsyncMethods
    {

        internal static async Task CallMethodAsync(string arg)
        {
            var result = await MethodAsync(arg);
            await Task.Delay(result);
            return result;

        }

        private static async Task MethodAsync(string arg)
        {
            var total = arg.First() + arg.Last();
            await Task.Delay(total);
            return total;
        }

    }
}
