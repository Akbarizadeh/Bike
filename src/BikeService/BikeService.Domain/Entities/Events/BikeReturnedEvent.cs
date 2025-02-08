using MsftFramework.Core.Domain.Events.External;
using MsftFramework.Core.Domain.Events.Internal;

public record BikeReturnedEvent(Guid BikeId, DateTime ReturnedAt) : IntegrationEvent;
public record BikeReturnedDomainEvent(Guid BikeId, DateTime ReturnedAt) : DomainEvent;
