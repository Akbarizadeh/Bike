using MsftFramework.Abstractions.Core.Domain.Events.Internal;
using MsftFramework.Abstractions.Core.Domain.Model;

namespace MsftFramework.Abstractions.Core.Domain.Events;

public interface IAggregatesDomainEventsStore
{
    IReadOnlyList<IDomainEvent> AddEventsFromAggregate<T>(T aggregate)
        where T : IHaveAggregate;

    void AddEvents(IReadOnlyList<IDomainEvent> events);

    IReadOnlyList<IDomainEvent> GetAllUncommittedEvents();
}