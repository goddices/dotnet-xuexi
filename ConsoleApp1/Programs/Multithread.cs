using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Programs
{
    internal static class Multithread
    {
        internal static void RunThread()
        {
            new Thread(Run).Start(11);
        }

        internal static void RunTask()
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            Task.Run(() => { Run(10); });

            Console.ReadLine();
            GC.Collect();
            Console.ReadLine();
        }


        internal static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine("TaskScheduler_UnobservedTaskException:" + e.Exception.ToString());
        }


        internal static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
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


        private static void Run(object i)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //未捕获异常会引起进程崩溃
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
