using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppNetCore.Programs;
using System.IO;
using System.Web;

namespace ConsoleAppNetCore
{
    class Program
    {
        public static void Main(params string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.WriteLine($"Current SynchronizationContext is {SynchronizationContext.Current?.ToString()}");

            //AutoMapperClient.Run();
            //TimeZoneInfoClient.Run();
            //EmbeddedResourceClient.Run();
            //QuartzCronExpressionClient.Run();
            //RsaSignClient.Run();
            //ZipFileClient.Run();
            string fileName = HttpUtility.UrlEncode(args[0])/*.Replace("\\", "/")*/;
            string fullPath = Path.Combine("/thisisrootdir1/dir2", fileName);
            Console.WriteLine(fullPath);
            Console.WriteLine(Path.GetFullPath(fullPath));
            Console.WriteLine(new Uri(Path.GetFullPath(fullPath)).ToString());
            Console.WriteLine(new Uri($"file://{Path.GetFullPath(fullPath)}").ToString());
            Console.WriteLine(new Uri($"file://{Path.GetFullPath(fullPath)}").OriginalString);
            Console.WriteLine(new Uri($"file://{Path.GetFullPath(fullPath)}").AbsolutePath);
            Console.WriteLine(new Uri($"file://{Path.GetFullPath(fullPath)}").LocalPath);
            //Console.WriteLine(result);
            //Console.ReadLine();
        }
    }


}
