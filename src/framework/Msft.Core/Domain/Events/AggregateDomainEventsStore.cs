using MsftFramework.Abstractions.Core.Domain.Events;
using MsftFramework.Abstractions.Core.Domain.Events.Internal;
using MsftFramework.Abstractions.Core.Domain.Model;

namespace MsftFramework.Core.Domain.Events;

public class AggregatesDomainEventsStore : IAggregatesDomainEventsStore
{
    private readonly List<IDomainEvent> _uncommittedDomainEvents = new();

    public IReadOnlyList<IDomainEvent> AddEventsFromAggregate<T>(T aggregate)
        where T : IHaveAggregate
    {
        var events = aggregate.GetUncommittedEvents();

        AddEvents(events);

        return events;
    }

    public void AddEvents(IReadOnlyList<IDomainEvent> events)
    {
        if (events.Any())
        {
            _uncommittedDomainEvents.AddRange(events);
        }
    }

    public IReadOnlyList<IDomainEvent> GetAllUncommittedEvents()
    {
        return _uncommittedDomainEvents;
    }
}