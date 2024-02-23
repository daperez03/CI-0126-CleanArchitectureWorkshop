using CleanArchitectureWorkshop.Application.Repositories;
using CleanArchitectureWorkshop.Domain.Entities;
using CleanArchitectureWorkshop.Domain.TeamAggregate;

namespace CleanArchitectureWorkshop.Application.UseCases;
public class TeamUsesCase : ITeamsUseCase
{
    private readonly ITeamsRepository _teamsRepository;

    public TeamUsesCase(ITeamsRepository teamsRepository)
    { 
        _teamsRepository = teamsRepository; 
    }

    public async Task<Team> AddPlayerToTeamAsync(string teamName, string playerName)
    {
        var teamID = TeamName.Create(teamName);

        var team = await _teamsRepository.GetByIdAsync(teamID)
            ?? throw new Exception("Team not found");

        var playerId = UserName.Create(playerName);
        var player = new Player(playerId);

        team.AddPlayer(player);

        await _teamsRepository.UpdateTeamAsync(team);

        return team;
    }

    public async Task<Team> CreateTeamAsync(string teamName)
    {
        var teamId = TeamName.Create(teamName);
        var team = new Team(teamId);

        await _teamsRepository.CreateTeamAsync(team);
        
        return team;
    }

    public async Task<List<Team>> GetAllTeamsAsync()
    {
        return await _teamsRepository.GetAllTeamsAsync();
    }

    public async Task<Team?> GetTeamByIdAsync(string teamName)
    {
        var teamId = TeamName.Create(teamName);
        return await _teamsRepository.GetByIdAsync(teamId);
    }

    public async Task<Team> RemovePlayerFromTeamAsync(string teamName, string playerName)
    {
        var teamId = TeamName.Create(teamName);

        var team = await _teamsRepository.GetByIdAsync(teamId)
            ?? throw new Exception("Team not found");

        var playerId = UserName.Create(playerName);

        team.RemovePlayer(playerId);

        await _teamsRepository.UpdateTeamAsync(team);

        return team;
    }
}
