using MsftFramework.Abstractions.Core.Domain.Events.Internal;

namespace MsftFramework.Abstractions.Core.Domain.Model;

public interface IHaveAggregate : IHaveVersion
{
    /// <summary>
    /// Add the <paramref name="domainEvent"/> ot the aggregate pending changes event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    void AddDomainEvent(IDomainEvent domainEvent);

    /// <summary>
    /// Returns all uncommitted events and clears this events from the aggregate.
    /// </summary>
    /// <returns>Array of new uncommitted events.</returns>
    IReadOnlyList<IDomainEvent> FlushUncommittedEvents();

    /// <summary>
    /// Return all uncommitted events.
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<IDomainEvent> GetUncommittedEvents();

    /// <summary>
    /// Clear all uncommitted events.
    /// </summary>
    void ClearUncommittedEvents();
}