using BitMiracle.Docotic;
using BitMiracle.Docotic.Pdf;
using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PdfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LicenseManager.AddLicenseData("40AGN-XTOUK-U9O74-3C1JQ-EOEHX");
            Console.WriteLine("Uid:" + LicenseManager.Uid);
            //string path = @"C:\Users\goddi\Downloads\10.1中标通知书.pdf";
            //string path = @"C:\Users\goddi\myspace\书\【JavaScript高级程序设计（第3版）】中文 高清 .pdf";
            var files = Directory.EnumerateFiles(@"C:\Users\goddi\Downloads\", "*.pdf");
            foreach (var file in files)
            {
                Process(file);
            }
        }

        static void Process(string file)
        {
            using (var pdfDocumentStream = File.OpenRead(file))
            {
                var document = new PdfDocument(pdfDocumentStream);

                PdfDrawOptions options = PdfDrawOptions.Create();
                options.BackgroundColor = new PdfRgbColor(255, 255, 255);
                var images = document.GetImages();
                int index = 0;
                foreach (var page in document.Pages)
                {
                    index++;
                    string imagePath = $@"C:\Users\goddi\Desktop\文档暂存\pdfimages\{ Path.GetFileName(file)}-{index}.jpg";
                    page.Save(new FileStream(imagePath, FileMode.Create), options);

                }
            }
        }
    }
}
