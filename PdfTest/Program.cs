using BitMiracle.Docotic.Pdf;
using System;
using System.Drawing;
using System.IO;

namespace PdfTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var pdfDocumentStream = File.OpenRead("jlwhs.pdf"))
            {
                var document = new PdfDocument(pdfDocumentStream);
                var page = document.Pages[0];
                PdfDrawOptions options = PdfDrawOptions.Create();
                options.BackgroundColor = new PdfRgbColor(255, 255, 255);
                options.Compression = ImageCompressionOptions.CreateJpeg();
                float resolutionRate = page.Canvas.Resolution / 200;
                options.HorizontalResolution = 200;
                options.VerticalResolution = 200;

                using (var memoryStream = new MemoryStream())
                {
                    page.Save(memoryStream, options);
                    byte[] byteArray = new byte[memoryStream.Length];
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.Read(byteArray, 0, byteArray.Length);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    using (Bitmap bitmap = new Bitmap(memoryStream))
                    {
                        int width = bitmap.Width;
                        int height = bitmap.Height;
                        Console.WriteLine("width:{0},substring 1000: {1}", width, Convert.ToBase64String(byteArray).Substring(0, 1000));
                    }
                }
            }
            Console.WriteLine("enter quit");
            Console.ReadLine();
        }
    }
}
