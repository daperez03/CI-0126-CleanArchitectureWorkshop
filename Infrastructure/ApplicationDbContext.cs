﻿using CleanArchitectureWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitectureWorkshop.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) 
    {
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
