using MsftFramework.Abstractions.Core.Domain.Events.External;

namespace MsftFramework.Core.Domain.Events.External;

public abstract record IntegrationEvent : Event, IIntegrationEvent
{
    public string CorrelationId { get; protected set; } = default;
}
