using DiFactory.FirstApproach;
using DiFactory.NormalApproach;
using DiFactory.SecondApproach;
using Microsoft.AspNetCore.Mvc;

namespace DiFactory.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IVehicle _vehicle;

    public TestController(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok(_vehicle.Name);
    }
}