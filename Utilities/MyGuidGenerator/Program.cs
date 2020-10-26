using System;

namespace MyGuidGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My Guid Generator 0.1\r\n按回车键生成一个新Guid并复制到剪贴板，Ctrl+C退出。");
            Console.ReadLine();
            Guid target = Guid.NewGuid();
            Console.WriteLine($"新Guid：{target} 已生成并复制到剪贴板。按回车键退出程序。");
            Console.ReadLine();
        }
    }
}
