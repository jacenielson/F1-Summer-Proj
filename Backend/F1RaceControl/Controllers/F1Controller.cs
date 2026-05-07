using Microsoft.AspNetCore.Mvc;
using F1RaceControl.Services;


namespace F1RaceControl.Controllers;

[ApiController] //Tells .Net this is an API, not a site
[Route("api/[controller]")] // Sets the URL to - /api/f1
public class F1Controller : ControllerBase
{
    private readonly IF1Service _f1Service;

    
    // This is called Dependency Injection
    public F1Controller(IF1Service f1Service)
    {
        _f1Service = f1Service;
    }

    [HttpGet("drivers/{sessionKey}")]
    public async Task<IActionResult> GetDrivers([FromRoute(Name = "sessionKey")] int sessionKey)
    {
       var drivers = await _f1Service.GetDriversAsync(sessionKey);
       return Ok(drivers);
    }

}