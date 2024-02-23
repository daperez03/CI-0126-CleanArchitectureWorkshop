namespace CleanArchitectureWorkshop.Domain.Core;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : ValueObject
{
    protected AggregateRoot(TId id) : base(id)
    {
    }

#pragma warning disable CS8618
    [Obsolete("Only meant to be used by EFCore")]
    protected AggregateRoot()
    {
    }
#pragma warning restore CS8618
}
