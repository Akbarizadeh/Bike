using Ardalis.GuardClauses;
using MsftFramework.Abstractions.Core.Domain.Events.Internal;

namespace MsftFramework.Core.Domain.Events;

public class DomainEventPublisher : IDomainEventPublisher
{

    public Task PublishAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        return PublishAsync(new[] { domainEvent }, cancellationToken);
    }

    public async Task PublishAsync(IDomainEvent[] domainEvents, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(domainEvents, nameof(domainEvents));

        if (domainEvents.Any() == false)
            return;

        await Task.CompletedTask;
    }
}
