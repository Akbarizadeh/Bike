using MsftFramework.Abstractions.Core.Domain.Events.Internal;

namespace MsftFramework.Abstractions.Core.Domain.Events;

public interface IDomainEventsAccessor
{
    IReadOnlyList<IDomainEvent> UnCommittedDomainEvents { get; }
}
