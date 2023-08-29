using Nograd.ProductService.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public interface IEventStore
    {
        Task SaveEventAsync(ProductCreatedEvent @event);  
    }
}
