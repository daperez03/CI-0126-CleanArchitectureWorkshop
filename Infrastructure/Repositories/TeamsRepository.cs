using CleanArchitectureWorkshop.Application.Repositories;
using CleanArchitectureWorkshop.Domain.Entities;
using CleanArchitectureWorkshop.Domain.TeamAggregate;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWorkshop.Infrastructure.Repositories;
internal class TeamsRepository : ITeamsRepository
{
    private readonly ApplicationDbContext _dbContex;
    public TeamsRepository(ApplicationDbContext dbContex)
    {
        _dbContex = dbContex;
    }
    public async Task CreateTeamAsync(Team team)
    {
        _dbContex.Teams.Add(team);
        await _dbContex.SaveChangesAsync();
    }

    public async Task<List<Team>> GetAllTeamsAsync()
    {
        return await _dbContex.Teams
            .Include(t => t.Players)
            .ToListAsync();
    }

    public async Task<Team?> GetByIdAsync(TeamName teamName)
    {
        return await _dbContex.Teams
            .Include(t => t.Players)
            .FirstOrDefaultAsync(t => t.Id == teamName);
    }

    public async Task UpdateTeamAsync(Team team)
    {
        _dbContex.Teams.Update(team);
        await _dbContex.SaveChangesAsync();
    }
}

