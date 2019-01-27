using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string f = "file1.txt";
            Console.WriteLine($"Current SynchronizationContext is {SynchronizationContext.Current?.ToString()}");
            // FileBeginEnd.Run(f);
            FileAsync.Run(f);
         

            
            Console.WriteLine("\n\n\n");
            Console.WriteLine("读文件完成。");
            Console.ReadLine();
        }



    }


}
