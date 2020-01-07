using ConsoleAppNetFramework.Programs;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNetFramework
{
    class Program
    {

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main(string[] args)
        {
            Console.WriteLine($"Current SynchronizationContext is {SynchronizationContext.Current?.ToString()}");

            FileAsyncReadClient.Run();
            MultiThreadClient.RunTask();
            MultiThreadClient.RunThread();
            VolatileClient.Run();
            VisableVolatileDemoClient.Run();
            MutexDemoClient.Run();
            MyMutexDemoWithTaskClient.RunAsync().Wait();
            Console.ReadLine();
        }

    }


}
