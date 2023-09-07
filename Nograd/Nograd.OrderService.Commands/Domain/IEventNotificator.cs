using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Domain;

public interface IEventNotificator
{
    public Task Notify(BaseEvent @event);
}