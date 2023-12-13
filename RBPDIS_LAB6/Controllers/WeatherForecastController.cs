using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RBPDIS_LAB6.Models;

namespace RBPDIS_LAB6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private RailwayTrafficContext _context;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, RailwayTrafficContext db)
        {
            _context = db;
            Console.WriteLine( "AAAAAAAAAAAAA" + db.Stops.First());
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Console.WriteLine("AAAAAAAAAAAAA" + _context.Stops.First());
            var el = _context.Trains.First();
            Console.WriteLine("SSSSSSSSSSS" + el.TrainStaffs + el.TrainNumber + el.TrainTypeId);
            var schedule = _context.Schedules
                .Include(s => s.Train)
                .First();
            Console.WriteLine("DDDDDDDD" + schedule.Train.TrainNumber + schedule.StopId + schedule.DayOfWeek);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}