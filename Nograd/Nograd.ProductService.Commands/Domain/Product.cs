using Nograd.ProductService.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public record Product (Guid Id, bool IsActive)
    {
        public static Product Create(ProductCreatedEvent @event)
        {
            return new Product(@event.ProductId, true);
        }

        public Product Apply(ProductCreatedEvent @event)
        {
            return this;
        }

        public Product Apply(ProductUpdatedEvent @event)
        {
            if (!IsActive)
            {
                throw new Exception($"The Product with id {Id} already has been deleted. It can't be updated.");
            }

            return this;
        }

        public Product Apply(ProductRemovedEvent @event)
        {
            if (!IsActive)
            {
                throw new Exception($"The Product with id {Id} already has been deleted.");
            }

            return this with { IsActive = false };
        }
    }
}
