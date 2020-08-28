using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ResourceWebTest.Resources;

namespace ResourceWebTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStringLocalizer<WeatherForecastController> _localizer;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IStringLocalizer<WeatherForecastController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        [HttpGet]
        public string[] Get()
        {
            var errormessage = Resource.ResourceManager.GetString("ErrorType1");

            var string1 = _localizer.GetString("String1").Value;

            return new[] { errormessage, string1, Resource.ErrorType1 };
        }
    }
}
