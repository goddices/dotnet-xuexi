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
            #region
            //FileAsyncReadClient.Run();
            //MultiThreadClient.RunTask();
            //MultiThreadClient.RunThread();
            //VolatileClient.Run();
            //VisableVolatileDemoClient.Run();
            //MutexDemoClient.Run();
            //MyMutexDemoWithTaskClient.RunAsync().Wait();
            #endregion
            var t = Test();
            t.Wait();
            var a = t.Result;
            Console.WriteLine(a);
            Console.ReadLine();
        }

        private static Task<int> Test()
        {
            return Task.FromResult(111);
        }

    }


}
