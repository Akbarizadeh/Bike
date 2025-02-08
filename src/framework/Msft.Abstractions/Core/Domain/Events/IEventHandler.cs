using MediatR;

namespace MsftFramework.Abstractions.Core.Domain.Events;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification
{
}
