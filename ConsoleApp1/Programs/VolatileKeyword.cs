using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Programs
{

    public class Worker
    {
        // This method is called when the thread is started.
        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("Worker thread: working...");
            }
            Console.WriteLine("Worker thread: terminating gracefully.");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Keyword volatile is used as a hint to the compiler that this data
        // member is accessed by multiple threads.
        private volatile bool _shouldStop;
    }

    /// <summary>
    /// https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/volatile
    /// </summary>
    public class VolatileKeyword
    {
        public static void Run()
        {
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Loop until the worker thread activates.
            while (!workerThread.IsAlive)
                ;

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work.
            Thread.Sleep(1);

            // Request that the worker thread stop itself.
            workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread 
            // until the object's thread terminates.
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }
        // Sample output:
        // Main thread: starting worker thread...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: working...
        // Worker thread: terminating gracefully.
        // Main thread: worker thread has terminated.
    }




    /// <summary>
    /// original resource:
    /// https://stackoverflow.com/questions/133270/illustrating-usage-of-the-volatile-keyword-in-c-sharp
    /// 
    /// 1.Release build
    /// 2.ctrl F5 
    /// 3.修改   public 【volatile】 int foo = 0;
    /// 加了没有死循环，不加死循环
    /// </summary>
    public class VisableVolatileDemo
    {
        volatile int foo = 0;

        public static void Run()
        {
            var test = new VisableVolatileDemo();

            new Thread(delegate () { Thread.Sleep(500); test.foo = 255; }).Start();

            while (true)
            {
                if (test.foo == 255)
                {
                    break;
                }
            };
            Console.WriteLine("OK");
        }
    }
}
