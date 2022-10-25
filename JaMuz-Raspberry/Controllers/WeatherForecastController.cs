using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotMuz.Database;
using DotMuz.Database.Models;

namespace JaMuzSharp.Controllers
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
        public List<File> Get()
        {
            using (var db = new JaMuzContext())
            {
                var files = db.File
                    .Where(b => b.Rating > 3 && b.Artist.Contains("Marley"))
                    .OrderBy(b => b.TrackNo)
                    .ToList();

                return files;
            }
        }
    }
}
