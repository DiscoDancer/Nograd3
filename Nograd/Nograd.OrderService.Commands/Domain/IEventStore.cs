using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Domain;

public interface IEventStore
{
    Task SaveEventAsync(BaseEvent @event, Guid orderId);
    Task<List<BaseEvent>> GetEventsAsync(Guid orderId);
}