using ConsoleApp1.Programs;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main(string[] args)
        {
            Console.WriteLine($"Current SynchronizationContext is {SynchronizationContext.Current?.ToString()}");

            //FileAsyncRead.Run();
            //Multithread.RunTask();
            //Multithread.RunThread();
            //VolatileKeyword.Run();
            VisableVolatileDemo.Run();
            Console.ReadLine();
        }

    }


}
