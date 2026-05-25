using System.Net.Http.Json;
using F1RaceControl.Models;

namespace F1RaceControl.Services;

public class F1Service : IF1Service
{
    private readonly HttpClient _httpClient;

    public F1Service(IHttpClientFactory httpClientFactory)
    {
        //The Service now manages the specific F1 client
        _httpClient = httpClientFactory.CreateClient("OpenF1");
    }

    public async Task<IEnumerable<DriverDto>> GetDriversAsync(int sessionKey)
    {
        var rawDrivers = await _httpClient.GetFromJsonAsync<List<OpenF1Driver>>($"drivers?session_key={sessionKey}");

        if(rawDrivers == null) return Enumerable.Empty<DriverDto>();

        return rawDrivers.Select(d => new DriverDto
        {
            DriverNumber = d.driver_number,
            FullName = d.full_name,
            TeamName = d.team_name,
            TeamColor = d.team_color,
            HeadshotUrl = d.headshot_url
        });
    }

    public async Task<IEnumerable<TeamSummaryDto>> GetTeamSummariesAsync(int sessionKey)
    {
        var drivers = await GetDriversAsync(sessionKey);
        var teamSummaries = drivers.GroupBy(d=> d.TeamName)
        .Select(group => new TeamSummaryDto
        {
            TeamName = group.Key,
            TeamColor = group.First().TeamColor,
            TotalDrivers = group.Count(),
            DriverNames = group.Select(d => d.FullName).ToList()
        })
        .OrderByDescending(t => t.TotalDrivers);

        return teamSummaries;
    }
        private record OpenF1Driver(int driver_number, string full_name, string team_name, string team_color, string headshot_url);

}