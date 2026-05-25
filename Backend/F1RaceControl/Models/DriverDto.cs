namespace F1RaceControl.Models;

public class DriverDto
{
    public int DriverNumber {get; set;}
    public string FullName {get; set;} = string.Empty;
    public string TeamName {get; set;} = string.Empty;
    public string TeamColor {get; set;} = string.Empty;
    public string HeadshotUrl {get; set;} = string.Empty;
}
