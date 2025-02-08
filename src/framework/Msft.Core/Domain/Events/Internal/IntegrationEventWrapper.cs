using MsftFramework.Abstractions.Core.Domain.Events.Internal;
using MsftFramework.Core.Domain.Events.External;

namespace MsftFramework.Core.Domain.Events.Internal;

public record IntegrationEventWrapper<TDomainEventType>(TDomainEventType DomainEvent) : IntegrationEvent
    where TDomainEventType : IDomainEvent;
