using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return new[]
            {
                new WeatherForecast
                {
                    Date = DateTime.MaxValue,
                    TemperatureC = 100,
                    Summary = "Too hot"
                }
            };
        }
    }
}
