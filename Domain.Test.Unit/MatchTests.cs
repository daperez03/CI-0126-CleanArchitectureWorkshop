using CleanArchitectureWorkshop.Domain.Entities;
using CleanArchitectureWorkshop.Domain.MatchAggregate;
using CleanArchitectureWorkshop.Domain.TeamAggregate;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWorkshop.Domain.Test.Unit;

public class MatchTests
{
    [Test]
    public void CreatingMatch_AssignsHomeTeam_Successfully()
    {
        // Arrage
        var homeTeamId = TeamName.Create("home");
        var awayTeamId = TeamName.Create("away");

        // Act
        var match = new Match(homeTeamId, awayTeamId);

        // Assert
        match.HomeTeamId.Should().Be(homeTeamId,
            because: "Match should assign the home team ID");
    }

    [Test]
    public void CreatingMatch_AssignsAwayTeam_Successfully()
    {
        // Arrage
        var homeTeamId = TeamName.Create("home");
        var awayTeamId = TeamName.Create("away");

        // Act
        var match = new Match(homeTeamId, awayTeamId);

        // Assert
        match.AwayTeamId.Should().Be(awayTeamId,
            because: "Match should assign the away team ID");
    }

    [Test]
    public void ConstructingMatch_ShouldGenerate_UniqueIds()
    {
        // Arrage
        var homeTeamId = TeamName.Create("home");
        var awayTeamId = TeamName.Create("away");

        // Act
        var match1 = new Match(homeTeamId, awayTeamId);
        var match2 = new Match(homeTeamId, awayTeamId);

        // Assert
        match1.Id.Should().NotBe(match2.Id,
            because: "Two different matches should always have diferents IDs");
    }

    [Test]
    public void Constructing_NewMatch_HasNotStaredState()
    {
        // Arrage
        var homeTeamId = TeamName.Create("home");
        var awayTeamId = TeamName.Create("away");

        // Act
        var match = new Match(homeTeamId, awayTeamId);

        // Assert
        match.State.Should().Be(MatchState.NotStarted,
            because: "Any newly created match has not started yet");
    }

}
