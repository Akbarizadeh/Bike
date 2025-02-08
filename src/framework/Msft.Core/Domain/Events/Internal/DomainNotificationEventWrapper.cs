using MsftFramework.Abstractions.Core.Domain.Events.Internal;

namespace MsftFramework.Core.Domain.Events.Internal;

public record DomainNotificationEventWrapper<TDomainEventType>(TDomainEventType DomainEvent) : DomainNotificationEvent
    where TDomainEventType : IDomainEvent;
