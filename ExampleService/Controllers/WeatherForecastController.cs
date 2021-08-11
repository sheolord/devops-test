using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleService.Controllers
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                if TemperatureC <= 0
                    Summary = Summaries[0]
                if TemperatureC > 1 && TemperatureC <= 7
                    Summary = Summaries[1]
                if TemperatureC > 8 && TemperatureC <= 11
                    Summary = Summaries[2]
                if TemperatureC > 12 && TemperatureC <= 15
                    Summary = Summaries[3]
                if TemperatureC > 16 && TemperatureC <= 19
                    Summary = Summaries[4]
                if TemperatureC > 20 && TemperatureC <= 23
                    Summary = Summaries[5]
                if TemperatureC > 24 && TemperatureC <= 27
                    Summary = Summaries[6]
                if TemperatureC > 28 && TemperatureC <= 30
                    Summary = Summaries[7]
                if TemperatureC > 31 && TemperatureC <= 35
                    Summary = Summaries[8]
                if TemperatureC >= 36
                    Summary = Summaries[9]
                // Summary = Summaries[rng.Next(Summaries.Length)]

            })
            .ToArray();
        }
    }
}
