using Microsoft.AspNetCore.Mvc;

namespace F1RaceControl.Controllers;

[ApiController] //Tells .Net this is an API, not a site
[Route("api/[controller]")] // Sets the URL to - /api/f1
public class F1Controller : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public F1Controller(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("drivers")]
    public async Task<IActionResult> GetDrivers()
    {
        var client = _httpClientFactory.CreateClient("OpenF1");
        var response = await client.GetAsync("drivers?session_key=9158");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine("F1 Data Fetched");
            Console.WriteLine(json.Substring(0, 500) + "..."); //Lost the first 500 char

            return Ok(json);
        }
        return BadRequest("Could not reach F1 API");
    }

}