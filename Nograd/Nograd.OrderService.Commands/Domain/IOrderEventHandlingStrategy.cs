using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Domain
{
    public interface IOrderEventHandlingStrategy
    {
        public Task HandleAsync(BaseEvent @event, Guid orderId);
    }
}
