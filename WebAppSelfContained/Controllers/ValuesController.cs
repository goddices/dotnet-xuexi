using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace WebAppSelfContained.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public async Task GetAsync([FromQuery] string q)
        {
            var process = Process.Start(@"c:\windows\system32\ipconfig.exe");
            process.StartInfo.RedirectStandardOutput = true;
            var a = process.Start();
            var output = process.StandardOutput;
            var buffer = new char[1024 * 1024];
            using (var writer = new StreamWriter(Response.Body))
            {
                while (0 != await output.ReadAsync(buffer, 0, buffer.Length))
                {
                    await writer.WriteAsync(buffer);
                }
                process.Kill();
            }
        }
    }
}
