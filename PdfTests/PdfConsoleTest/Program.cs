using BitMiracle.Docotic;
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

            Console.WriteLine("Uid:" + LicenseManager.Uid);

            if (args == null || args.Length < 1)
            {
                Console.WriteLine("One parameter is required");
                return;
            }
            string filename = args[0];
            Console.WriteLine("pdf file:" + filename);

            LicenseManager.Reset();
            LicenseManager.AddLicenseData("");
            using (var pdfDocumentStream = File.OpenRead(filename))
            {
                var document = new PdfDocument(pdfDocumentStream);
                int index = 0;
                foreach (var page in document.Pages)
                {
                    PdfDrawOptions options = PdfDrawOptions.Create();
                    options.BackgroundColor = new PdfRgbColor(255, 255, 255);
                    options.Compression = ImageCompressionOptions.CreateJpeg();
                    double resolutionRate = page.Resolution / 200;
                    options.HorizontalResolution = 200;
                    options.VerticalResolution = 200;

                    using (var memoryStream = new FileStream(filename + "_index_" + index + ".jpg", FileMode.Create))
                    {
                        page.Save(memoryStream, options);
                    }
                    index++;
                }
            }
            Console.WriteLine("press enter quit");
            Console.ReadLine();
        }
    }
}
