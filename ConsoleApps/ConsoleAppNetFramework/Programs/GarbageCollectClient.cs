using System;

namespace ConsoleAppNetFramework.Programs
{
    public class GarbageCollectClient
    {
        public static void Run()
        {
            String obj1 = ";asdf";
            int gen_of_obj1 = GC.GetGeneration(obj1);
            Console.WriteLine($"generation of obj1 = {gen_of_obj1}");

            GC.Collect();
            GC.Collect();

            byte[] large_array = new byte[85001];
            int gen_of_large_array = GC.GetGeneration(large_array);
            Console.WriteLine($"generation of large_array = {gen_of_large_array}");

            Console.WriteLine("press enter key to quit...");
            Console.ReadLine();
        }
    }
}
