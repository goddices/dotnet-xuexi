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

            Console.WriteLine("Uid:" + LicenseManager.Uid);
            //string path = @"C:\Users\goddi\Downloads\10.1中标通知书.pdf";
            //string path = @"C:\Users\goddi\myspace\书\【JavaScript高级程序设计（第3版）】中文 高清 .pdf";
            string path = @"C:\Users\goddi\Downloads\10.1中标通知书.pdf";
            LicenseManager.Reset();
            LicenseManager.AddLicenseData("40AGN-XTOUK-U9O74-3C1JQ-EOEHX");
            using (var pdfDocumentStream = File.OpenRead(path))
            {
                var document = new PdfDocument(pdfDocumentStream);

                PdfDrawOptions options = PdfDrawOptions.Create();
                options.BackgroundColor = new PdfRgbColor(255, 255, 255);
                var images = document.GetImages();
                int index = 0;
                foreach (var page in document.Pages)
                {
                    index++;
                    string imagePath = @"C:\Users\goddi\Desktop\文档暂存\pdfimages\test2\{0}.jpg";
                    page.Save(new FileStream(string.Format(imagePath, index), FileMode.Create), options);

                }

                //int index = 0;
                //foreach (var page in document.Pages)
                //{
                //    PdfDrawOptions options = PdfDrawOptions.Create();
                //    options.BackgroundColor = new PdfRgbColor(255, 255, 255);
                //    options.Compression = ImageCompressionOptions.CreateJpeg();
                //    double resolutionRate = page.Resolution / 200;
                //    options.HorizontalResolution = 200;
                //    options.VerticalResolution = 200;

                //    using (var memoryStream = new FileStream(filename + "_index_" + index + ".jpg", FileMode.Create))
                //    {
                //        page.Save(memoryStream, options);
                //    }
                //    index++;
                //}
            }
            Console.WriteLine("press enter quit");
            Console.ReadLine();
        }
    }
}
