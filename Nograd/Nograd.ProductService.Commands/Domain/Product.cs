using Nograd.ProductService.Commands.Domain.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public record Product (Guid Id, ProductLifecycleStates State)
    {
        public static Product GetNotCreatedProduct()
        {
            return new Product(Guid.Empty, ProductLifecycleStates.ToBeCreated);
        }

        public Product Apply(ProductCreatedEvent @event)
        {
            return new Product(Id: @event.ProductId, State: ProductLifecycleStates.Created);
        }

        public Product Apply(ProductUpdatedEvent @event)
        {
            return this;
        }

        public Product Apply(ProductRemovedEvent @event)
        {
            return this with { State = ProductLifecycleStates.Deleted };
        }
    }
}
