using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Infrastructure.EventStore;

public sealed class EventStore : IEventStore
{
    public Task SaveEventAsync(BaseEvent @event, Guid orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<BaseEvent>> GetEventsAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }
}