using DiFactory.FirstApproach;
using DiFactory.SecondApproach;
using Microsoft.AspNetCore.Mvc;

namespace DiFactory.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IFoodFactory _foodFactory;

    public TestController(IFoodFactory foodFactory)
    {
        _foodFactory = foodFactory;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok(_foodFactory.Create(Food.Chips).Name);
    }
}