using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace ConsoleAppNetCore.Programs
{
    public static class ZipFileClient
    {
        public static void Run()
        {
            ZipArchive zip = new ZipArchive(new FileStream(@"C:\Users\goddi\Desktop\log.log", FileMode.Open), ZipArchiveMode.Read);
            zip.Entries.First(x => x.Name == "aabc");
        }
    }
}
