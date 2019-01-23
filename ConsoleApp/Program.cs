using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Current SynchronizationContext is {SynchronizationContext.Current?.ToString()}");
            Console.ReadLine();
        }
    }

 
}
