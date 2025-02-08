using Ardalis.GuardClauses;
using MsftFramework.Abstractions.Core.Domain.Events.External;

namespace MsftFramework.Core.Domain.Events;

public class IntegrationEventPublisher : IIntegrationEventPublisher
{

    public Task PublishAsync(IIntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(integrationEvent, nameof(integrationEvent));
       return Task.CompletedTask;
    }

    public async Task PublishAsync(IIntegrationEvent[] integrationEvents, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(integrationEvents, nameof(integrationEvents));

        foreach (var integrationEvent in integrationEvents)
        {
            await PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
