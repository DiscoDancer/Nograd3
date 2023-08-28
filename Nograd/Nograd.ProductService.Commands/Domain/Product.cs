using Nograd.ProductService.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public record Product (Guid Id, bool IsActive)
    {
        public static Product Create(ProductCreatedEvent @event)
        {
            return new Product(@event.ProductId, true);
        }

        public Product Apply(ProductRemovedEvent @event)
        {
            return this with { IsActive = false };
        }
    }
}
