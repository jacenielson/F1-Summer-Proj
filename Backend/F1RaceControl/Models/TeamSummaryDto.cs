namespace F1RaceControl.Models;

public class TeamSummaryDto
{
    public string TeamName {get; set;} = string.Empty;
    public string TeamColor {get; set;} = string.Empty;
    public int TotalDrivers{get; set;}
    public List<string> DriverNames {get; set;} = new();
}