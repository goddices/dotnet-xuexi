using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Programs
{
    /// <summary>
    /// 互斥锁的例子
    /// https://docs.microsoft.com/en-us/dotnet/api/system.threading.mutex?view=netframework-4.8
    /// </summary>
    public class MutexDemo
    {
        private static Mutex mut = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 3;
        public static void Run()
        {
            // Create the threads that will use the protected resource.
            for (int i = 0; i < numThreads; i++)
            {
                Thread newThread = new Thread(new ThreadStart(ThreadProc));
                newThread.Name = String.Format("Thread{0}", i + 1);
                newThread.Start();
            }

            // The main thread exits, but the application continues to
            // run until all foreground threads have exited.
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        // This method represents a resource that must be synchronized
        // so that only one thread at a time can enter.
        private static void UseResource()
        {
            // Wait until it is safe to enter.
            Console.WriteLine("{0} is requesting the mutex",
                              Thread.CurrentThread.Name);
            mut.WaitOne();

            Console.WriteLine("{0} has entered the protected area",
                              Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(500);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.Name);

            // Release the Mutex.
            mut.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex",
                Thread.CurrentThread.Name);
        }
    }
    // The example displays output like the following:
    //       Thread1 is requesting the mutex
    //       Thread2 is requesting the mutex
    //       Thread1 has entered the protected area
    //       Thread3 is requesting the mutex
    //       Thread1 is leaving the protected area
    //       Thread1 has released the mutex
    //       Thread3 has entered the protected area
    //       Thread3 is leaving the protected area
    //       Thread3 has released the mutex
    //       Thread2 has entered the protected area
    //       Thread2 is leaving the protected area
    //       Thread2 has released the mutex
}

namespace ConsoleApp1.Programs
{
    public class MyMutexDemoWithTask
    {
        private static Mutex mut = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 5;
        public static async Task RunAsync()
        {
            await Task.Run(async () =>
            {
                for (int i = 0; i < numThreads; i++)
                {
                    //Thread newThread = new Thread(new ThreadStart(ThreadProc));
                    await ThreadProc();
                    //newThread.Name = String.Format("Thread{0}", i + 1);
                    //newThread.Start();
                }
            });
            // The main thread exits, but the application continues to
            // run until all foreground threads have exited.
        }

        private static async Task ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                await UseResource();
            }
        }

        // This method represents a resource that must be synchronized
        // so that only one thread at a time can enter.
        private static async Task UseResource()
        {
            // Wait until it is safe to enter.
            Console.WriteLine("{0} is requesting the mutex",
                              Thread.CurrentThread.ManagedThreadId);
            mut.WaitOne();

            Console.WriteLine("{0} has entered the protected area",
                              Thread.CurrentThread.ManagedThreadId);

            // Place code to access non-reentrant resources here.

            await Task.Delay(1000);

            Console.WriteLine("{0} is leaving the protected area",
                Thread.CurrentThread.ManagedThreadId);

            // Release the Mutex.
            mut.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex",
                Thread.CurrentThread.ManagedThreadId);
        }
    }
}
  