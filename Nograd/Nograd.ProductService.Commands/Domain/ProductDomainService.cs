using Nograd.ProductService.Commands.Domain.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public static class ProductDomainService
    {
        public static ProductCreatedEvent Create(
            Product product,
            string name,
            string description,
            string category,
            decimal price,
            Guid productId
        )
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            if (string.IsNullOrWhiteSpace(category)) throw new ArgumentNullException(nameof(category));
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));
            if (productId == Guid.Empty) throw new ArgumentException(nameof(productId));

            if (product.State != ProductLifecycleStates.ToBeCreated)
            {
                throw new Exception($"Product with id {productId} already has been created");
            }

            return new ProductCreatedEvent
            {
                Category = category,
                Price = price,
                ProductId = productId,
                Name = name,
                Description = description,
            };
        }

        public static ProductUpdatedEvent Update(
            Product product,
            string name,
            string description,
            string category,
            decimal price
        )
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            if (string.IsNullOrWhiteSpace(category)) throw new ArgumentNullException(nameof(category));
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));
            if (product == null) throw new ArgumentException(nameof(product));
            if (product.Id == Guid.Empty) throw new ArgumentException(nameof(product.Id));

            if (product.State != ProductLifecycleStates.Created)
            {
                throw new Exception($"The Product with id {product.Id} already has been removed or it is not yet created. So it can't be updated.");
            }

            return new ProductUpdatedEvent
            {
                Category = category,
                Price = price,
                ProductId = product.Id,
                Description = description,
                Name = name,
            };
        }

        public static ProductRemovedEvent Remove(Product product)
        {
            if (product.Id == Guid.Empty) throw new ArgumentException(nameof(product.Id));

            if (product.State != ProductLifecycleStates.Created)
            {
                throw new Exception($"The Product with id {product.Id} already has been removed or it is not yet created. So it can't be removed.");
            }

            return new ProductRemovedEvent(product.Id);
        }
    }
}
