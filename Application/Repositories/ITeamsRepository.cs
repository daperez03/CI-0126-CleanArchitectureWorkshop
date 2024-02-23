﻿

using CleanArchitectureWorkshop.Domain.Core;
using CleanArchitectureWorkshop.Domain.Entities;
using CleanArchitectureWorkshop.Domain.TeamAggregate;

namespace CleanArchitectureWorkshop.Application.Repositories;
public interface ITeamsRepository : IRepository<Team, TeamName>
{
    public Task<Team?> GetByIdAsync(TeamName teamName);

    public Task<List<Team>> GetAllTeamsAsync();

    public Task CreateTeamAsync(Team team);

    public Task UpdateTeamAsync(Team team);
}

