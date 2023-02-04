using DiFactory.FirstApproach;
using Microsoft.AspNetCore.Mvc;

namespace DiFactory.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IDrinkFactory _drinkFactory;

    public TestController(IDrinkFactory drinkFactory)
    {
        _drinkFactory = drinkFactory;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok(_drinkFactory.Get("").Type);
    }
}