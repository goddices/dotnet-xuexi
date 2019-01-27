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
    public class FileAsync
    {
        public static void Run(string filePath)
        {
            FileAsync file = new FileAsync(filePath);
            Task t = file.ReadFile();
            t.Wait();
        }

        private const int BUFFER_SIZE = 4096;
        private byte[] buffer = new byte[BUFFER_SIZE];
        private StringBuilder sb = new StringBuilder();
        private string filePath = "";

        public FileAsync(string filePath)
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
}
