using Nograd.ProductService.Commands.Domain.Events;

namespace Nograd.ProductService.Commands.Features.Base
{
    public interface IProductEventHandlingStrategy
    {
        public Task HandleAsync(BaseEvent @event, Guid productId);
    }
}
