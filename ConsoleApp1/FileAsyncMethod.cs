using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp
{
    public static class FileAsyncMethod
    {
        public async static string ReadFile(string filePath)
        {
            Stream fs = new FileStream(filePath, FileMode.Open);
            fs.ReadAsync()
        }
    }
}
