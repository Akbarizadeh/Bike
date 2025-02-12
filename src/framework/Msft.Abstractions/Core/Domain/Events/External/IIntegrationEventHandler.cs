namespace MsftFramework.Abstractions.Core.Domain.Events.External;

public interface IIntegrationEventHandler<in TEvent> : IEventHandler<TEvent>
    where TEvent : IIntegrationEvent
{
}
