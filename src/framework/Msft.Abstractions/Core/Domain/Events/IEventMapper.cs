using MsftFramework.Abstractions.Core.Domain.Events.External;
using MsftFramework.Abstractions.Core.Domain.Events.Internal;

namespace MsftFramework.Abstractions.Core.Domain.Events;

public interface IEventMapper : IIDomainNotificationEventMapper, IIntegrationEventMapper
{
}

public interface IIDomainNotificationEventMapper
{
    IReadOnlyList<IDomainNotificationEvent?>? MapToDomainNotificationEvents(IReadOnlyList<IDomainEvent> domainEvents);
    IDomainNotificationEvent? MapToDomainNotificationEvent(IDomainEvent domainEvent);
}

public interface IIntegrationEventMapper
{
    IReadOnlyList<IIntegrationEvent?>? MapToIntegrationEvents(IReadOnlyList<IDomainEvent> domainEvents);
    IIntegrationEvent? MapToIntegrationEvent(IDomainEvent domainEvent);
}
