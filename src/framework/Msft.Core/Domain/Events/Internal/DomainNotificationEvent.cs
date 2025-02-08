using MsftFramework.Abstractions.Core.Domain.Events.Internal;

namespace MsftFramework.Core.Domain.Events.Internal;

public abstract record DomainNotificationEvent : Event, IDomainNotificationEvent;
