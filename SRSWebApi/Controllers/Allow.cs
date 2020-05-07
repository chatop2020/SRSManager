using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SRSWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class Allow: ControllerBase
    {
        private readonly ILogger<Allow> _logger;

        public Allow(ILogger<Allow> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        [Route("allow/test")]
        public string Test()
        {
            return "ok";
        }
        /*[HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }*/
    }
}