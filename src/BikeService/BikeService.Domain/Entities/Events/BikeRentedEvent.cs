using MsftFramework.Abstractions.Core.Domain.Events.Internal;
using MsftFramework.Core.Domain.Events.External;
using MsftFramework.Core.Domain.Events.Internal;

public record BikeRentedEvent(Guid BikeId, Guid UserId, DateTime RentedAt) : IntegrationEvent;
public record BikeRentedDomainEvent(Guid BikeId, Guid UserId, DateTime RentedAt) : DomainEvent;

