using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

// Attributes
    // Every controller has attributes
[ApiController]
[Route("[controller]")] // localhost:5000/weatherforecast

public class WeatherForecastController : ControllerBase
{
    // A private array of strings that summarize the weather
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // contextual data for use in the constructor
    private readonly ILogger<WeatherForecastController> _logger;

    // Dependency Injection - This is the contructor
        // Making something available to the controller
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }
    
    // Endpoint 
        // Specifies which method will be used
    [HttpGet(Name = "GetWeatherForecast")]
    
    // The method and logic for the endpoint?
    public IEnumerable<WeatherForecast> Get()
    {
        // Returns an array with .ToArray() of WeatherForecast objects
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
