using Nograd.ProductService.Commands.Domain.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public interface IEventNotificator
    {
        public Task Notify(BaseEvent @event);
    }
}
