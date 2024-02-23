using CleanArchitectureWorkshop.Domain.Core;
using CleanArchitectureWorkshop.Domain.Entities;
using CleanArchitectureWorkshop.Domain.TeamAggregate;

namespace CleanArchitectureWorkshop.Domain.MatchAggregate;

public class Match : AggregateRoot<MatchId>
{
    public TeamName HomeTeamId { get; }
    
    public TeamName AwayTeamId { get; }

    public MatchState State { get; }
    
    public Match(TeamName homeTeamId, TeamName awayTeamId) 
        : base(MatchId.CreateUnique())
    {
        HomeTeamId = homeTeamId;
        AwayTeamId = awayTeamId;
        State = MatchState.NotStarted;
    }
}
