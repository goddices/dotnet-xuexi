using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class FileBeginEnd
    {
        private struct AsyncState
        {
            public Stream Stream;
            public ManualResetEvent MRE;
        }

        public static void Run(string filePath)
        {
            FileBeginEnd file = new FileBeginEnd(filePath);
            file.ReadFile(); 
        }


        private const int BUFFER_SIZE = 4096;
        private byte[] buffer = new byte[BUFFER_SIZE];
        private StringBuilder sb = new StringBuilder();
        private string filePath = "";

        public FileBeginEnd(string filePath)
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
