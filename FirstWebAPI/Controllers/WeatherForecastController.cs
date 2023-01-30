using Microsoft.AspNetCore.Mvc;

//CONTROLLERS
//Used to handle web pages, not API requests
namespace FirstWebAPI.Controllers 
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

        //Only action in this class as of right now
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //This segment below should be an example of a Controller Action
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            //This is more or less an Action Result, usually a ViewResult tho
            //Usually return a method of the Controller base class instead of an action result directly
            //ie. return View();
            .ToArray();
        }
    }
}