using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UnknownModelBindersExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("One")]
        public IActionResult Get([FromQuery] ExampleObject example)
        {
            return Ok(example);
        }

        [HttpGet("Two")]
        public IActionResult GetArrayExample([FromQuery] ExampleObject[] example)
        {
            return Ok(example);
        }
        
        // Noice that when binding is done from the body, our StringBinderProvider only gets hit once - with the complex type
        // Why is the behaviour different here than when we have a [FromQuery] attribute applied?
        // Shouldn't [FromQuery] work the same way, and/or only provide its properties if the returned complex type is not handled?
        [HttpPost("Three")]
        public IActionResult PostFromBody([FromBody] ExampleObject example)
        {
            return Ok(example);
        }
    }
}
