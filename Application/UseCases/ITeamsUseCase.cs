﻿using CleanArchitectureWorkshop.Domain.Entities;

namespace CleanArchitectureWorkshop.Application.UseCases;

public interface ITeamsUseCase
{
    public Task<Team> CreateTeamAsync(string teamName);
    public Task<Team> AddPlayerToTeamAsync(string teamName, string playerName);
    public Task<Team> RemovePlayerFromTeamAsync(string teamName, string playerName);

    public Task<Team?> GetTeamByIdAsync(string teamName);

    public Task<List<Team>> GetAllTeamsAsync();
}
 