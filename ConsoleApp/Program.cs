using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main(string[] args)
        {     
             
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //string f = "file1.txt";
            //Console.WriteLine($"Current SynchronizationContext is {SynchronizationContext.Current?.ToString()}");
            //// FileBeginEnd.Run(f);
            //FileAsync.Run(f);

            //Console.WriteLine("\n\n\n");
            //Console.WriteLine("读文件完成。");
            //TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
           
                new Thread(Run).Start();
                //Task.Run(() => { Run(i); });
           
            Console.ReadLine();
            GC.Collect();
            Console.ReadLine();
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine("TaskScheduler_UnobservedTaskException:" + e.Exception.ToString());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Console.WriteLine("CurrentDomain_UnhandledException:" + e.ExceptionObject);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Run(object i)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //try
            //{

            Console.WriteLine("Thread Run");
            Thread.Sleep(1000);
            throw new Exception("mean to throw");
            //}
            //catch
            //{
            //    Console.WriteLine("exception");
            //}
        }



    }


}
