using Microsoft.Extensions.DependencyInjection;
using MsftFramework.Abstractions.Core.Domain.Events.Internal;

namespace MsftFramework.Core.Domain.Events.Internal;

/// <summary>
public static class DomainEventsHandler
{

    public static async Task RaiseDomainEventAsync(
        IDomainEvent[] domainEvents,
        CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }

    public static async Task RaiseDomainEventAsync(
        IDomainEvent domainEvent,
        CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }

    public static void RaiseDomainEvent(
        IDomainEvent domainEvent,
        CancellationToken cancellationToken = default)
    {
    }
}
