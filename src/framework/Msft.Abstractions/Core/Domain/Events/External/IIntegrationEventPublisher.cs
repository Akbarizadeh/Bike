namespace MsftFramework.Abstractions.Core.Domain.Events.External;

public interface IIntegrationEventPublisher
{
    Task PublishAsync(IIntegrationEvent integrationEvent, CancellationToken cancellationToken = default);
    Task PublishAsync(IIntegrationEvent[] integrationEvents, CancellationToken cancellationToken = default);
}
