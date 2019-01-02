using System;
using System.Collections.Generic;
using System.Text;

namespace GarbgeCollect
{
    class Program
    {
        static void Main(string[] args)
        {
            String obj1 = ";asdf";
            int gen_of_obj1 = GC.GetGeneration(obj1);
            Console.WriteLine($"generation of obj1 = {gen_of_obj1}");

            GC.Collect();
            GC.Collect();
            GC.
            byte[] large_array = new byte[85001];
            int gen_of_large_array = GC.GetGeneration(large_array);
            Console.WriteLine($"generation of large_array = {gen_of_large_array}");

            Console.WriteLine("press enter key to quit...");
            Console.ReadLine();
        }
    }
}
