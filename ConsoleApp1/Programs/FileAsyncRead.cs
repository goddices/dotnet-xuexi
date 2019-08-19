using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Programs
{
    public static class FileAsyncRead
    {
        public static void Run()
        {
            string f = "file1.txt";

            BeginEndMethod.Run(f);
            AsyncMethod.Run(f);

            Console.WriteLine("\n\n\n");
            Console.WriteLine("读文件完成。"); 
        }
    }
    internal class AsyncMethod
    {
        public static void Run(string filePath)
        {
            AsyncMethod file = new AsyncMethod(filePath);
            Task t = file.ReadFile();
            t.Wait();
        }

        private const int BUFFER_SIZE = 4096;
        private byte[] buffer = new byte[BUFFER_SIZE];
        private StringBuilder sb = new StringBuilder();
        private string filePath = "";

        public AsyncMethod(string filePath)
        {
            this.filePath = filePath;
        }

        private async Task ReadFile()
        {

            int offerset = 0;

            Stream fs = new FileStream(filePath, FileMode.Open);


            Debug.WriteLine($"Current Thread Id = {Thread.CurrentThread.ManagedThreadId}", "Before BeginRead");
            int bytes = 0;
            do
            {
                bytes = await fs.ReadAsync(buffer, offerset, BUFFER_SIZE);
                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
            } while (bytes != 0);

            Debug.WriteLine($"Current Thread Id = {Thread.CurrentThread.ManagedThreadId}", "After BeginRead");

            Console.WriteLine(sb.ToString());

            fs.Dispose();
        }

    }


    internal class BeginEndMethod
    {
        private struct AsyncState
        {
            public Stream Stream;
            public ManualResetEvent MRE;
        }

        public static void Run(string filePath)
        {
            BeginEndMethod file = new BeginEndMethod(filePath);
            file.ReadFile();
        }


        private const int BUFFER_SIZE = 4096;
        private byte[] buffer = new byte[BUFFER_SIZE];
        private StringBuilder sb = new StringBuilder();
        private string filePath = "";

        public BeginEndMethod(string filePath)
        {
            this.filePath = filePath;
        }

        private void ReadFile()
        {

            int offerset = 0;

            Stream fs = new FileStream(filePath, FileMode.Open);
            var state = new AsyncState
            {
                MRE = new ManualResetEvent(false),
                Stream = fs
            };

            Debug.WriteLine($"Current Thread Id = {Thread.CurrentThread.ManagedThreadId}", "Before BeginRead");
            IAsyncResult ar = fs.BeginRead(buffer, offerset, BUFFER_SIZE, ReadFileCallback, state);

            //WaitOne阻塞调用者的线程
            state.MRE.WaitOne();
            Debug.WriteLine($"Current Thread Id = {Thread.CurrentThread.ManagedThreadId}", "After BeginRead");

            Console.WriteLine(sb.ToString());

            fs.Dispose();
        }

        private void ReadFileCallback(IAsyncResult result)
        {
            Debug.WriteLine($"Current Thread Id = {Thread.CurrentThread.ManagedThreadId}", "In Callback");
            AsyncState state = (AsyncState)result.AsyncState;

            int bytes = state.Stream.EndRead(result);

            sb.Append(Encoding.UTF8.GetString(buffer, 0, bytes));

            if (bytes == 0)
            {
                state.MRE.Set();
            }
            else
            {
                IAsyncResult ar = state.Stream.BeginRead(buffer, 0, BUFFER_SIZE, ReadFileCallback, state);
            }
        }
    }
}
