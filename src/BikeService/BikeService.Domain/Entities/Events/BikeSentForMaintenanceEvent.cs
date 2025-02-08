using MsftFramework.Core.Domain.Events.External;
using MsftFramework.Core.Domain.Events.Internal;

public record BikeSentForMaintenanceEvent(Guid BikeId, DateTime SentAt) : IntegrationEvent;
public record BikeSentForMaintenanceDomainEvent(Guid BikeId, DateTime SentAt) : DomainEvent;

