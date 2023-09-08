using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Infrastructure.EventNotifications;

public sealed class EventNotificator : IEventNotificator
{
    public Task Notify(BaseEvent @event)
    {
        return Task.CompletedTask;
    }
}