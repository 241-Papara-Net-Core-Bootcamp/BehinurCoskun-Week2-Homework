using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaparaSecondWeek.Extensions.DateTimeExtension;
using PaparaSecondWeek.Extensions.IntExtension;
using PaparaSecondWeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaparaSecondWeek.Controllers
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
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("NumberCheck")]
        public IActionResult GetNumber()
        {
            int number = 10;
            bool result = number.IsGreaterThan(100);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetMonth")]
        public IActionResult GetMonth()
        {
            var date = DateTime.Now.GetMonth();
            return Ok(date);
        }

        [HttpGet("FormatDate")]
        public IActionResult FormatDate()
        {
            var formattedDate = DateTime.Now.FormatDate();
            return Ok(formattedDate);
        }
        [HttpGet("FormatDateTime")]
        public IActionResult FormatDateTime()
        {
            var formattedDate = DateTime.Now.FormatDate("yyyy-MM-dd HH:mm:ss");
            return Ok(formattedDate);
        }


    }
}
