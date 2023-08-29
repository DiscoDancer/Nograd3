using Nograd.ProductService.Events;

namespace Nograd.ProductService.Commands.Domain
{
    public static class ProductDomainService
    {
        public static ProductCreatedEvent Create(
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

            return new ProductCreatedEvent(
                name: name,
                description: description,
                category: category,
                price: price,
                productId: productId);
        }

        public static ProductCreatedEvent Update(
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

            if (!product.IsActive)
            {
                throw new Exception($"The product with id {product.Id} has been removed. Not possible to update it.");
            }

            return new ProductCreatedEvent(
                name: name,
                description: description,
                category: category,
                price: price,
                productId: product.Id);
        }
    }
}
