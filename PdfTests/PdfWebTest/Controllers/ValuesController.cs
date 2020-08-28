using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BitMiracle.Docotic;
using BitMiracle.Docotic.Pdf;
using Microsoft.Extensions.Options;

namespace PdfWebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IPdfService pdfService;
        public ValuesController(IPdfService pdfService)
        {
            this.pdfService = pdfService;
        }

        public async Task<IActionResult> Get()
        {
            return File(await pdfService.FirstPage(), "image/jpg");
        }
    }

    public class RecognizeOptions
    {
        /// <summary>
        /// Factor of min intersect area
        /// </summary>
        public double MinIntersectAreaPercentage { get; set; } = 0.7;

        /// <summary>
        /// Factor of deviation of texts y in the same line
        /// </summary>
        public double TextLineDeviationPercentage { get; set; } = 0.1;

        /// <summary>
        /// pdf library license key
        /// </summary>
        public string LicenceKey { get; set; } = "";
    }

    public interface IPdfService
    {
        Task<Stream> FirstPage();
    }

    public class PdfService : IPdfService
    {
        public PdfService(
            IOptionsMonitor<RecognizeOptions> recognizeOptions)
        {
            LicenseManager.AddLicenseData(recognizeOptions.CurrentValue.LicenceKey);
        }

        public Task<Stream> FirstPage()
        {
            return Task.Run(async () =>
            {
                return await Inner();
            });
        }

        private async Task<Stream> Inner()
        {
            var filename = "我的简历.pdf";

            using (var pdfDocumentStream = File.OpenRead(filename))
            {
                var document = new PdfDocument(pdfDocumentStream);
                var page = document.Pages[0];
                PdfDrawOptions options = PdfDrawOptions.Create();
                options.BackgroundColor = new PdfRgbColor(255, 255, 255);
                options.Compression = ImageCompressionOptions.CreateJpeg();
                double resolutionRate = page.Resolution / 200;
                options.HorizontalResolution = 200;
                options.VerticalResolution = 200;

                var memoryStream = new MemoryStream();
                {
                    page.Save(memoryStream, options);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                return await Task.FromResult(memoryStream);
            }
        }
    }
}
