using Nograd.ProductService.Events;

namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    public static class CreateProductDomainService
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
    }
}
