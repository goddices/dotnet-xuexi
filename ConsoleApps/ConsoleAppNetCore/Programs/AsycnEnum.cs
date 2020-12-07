using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNetCore.Programs
{
    public static class AsycnEnum
    {
        public static void Run()
        {
            var a = GetAsync();
            Console.WriteLine(a);
        }

        private static async Task<IAsyncEnumerable<int>> GetAsync()
        {
            return Generate();
        }

        private static async IAsyncEnumerable<int> Generate()
        {
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(0);
                yield return i;
            }
        }
    }
}
