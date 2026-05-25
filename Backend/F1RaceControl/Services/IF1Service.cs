// This is the interface
using F1RaceControl.Models;

namespace F1RaceControl.Services;

public interface IF1Service
{
    Task<IEnumerable<DriverDto>> GetDriversAsync(int sessionkey);
    Task<IEnumerable<TeamSummaryDto>> GetTeamSummariesAsync(int sessionKey);
}