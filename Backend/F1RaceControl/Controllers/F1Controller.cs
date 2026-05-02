using Microsoft.AspNetCore.Mvc;

namespace F1RaceControl.Controllers;

[ApiController] //Tells .Net this is an API, not a site
[Route("api/[controller]")] // Sets the URL to - /api/f1
public class F1Controller : ControllerBase
{
    [HttpGet("hello")]
    public IActionResult GetHello()
    {
        return Ok(new {message = "Box, Box! API works"});
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        var status = new
        {
            Connection = "Stable",
            TargetAPI = "OpenF1",
            Timestamp = DateTime.Now
        };

        return Ok(status);
    }
}