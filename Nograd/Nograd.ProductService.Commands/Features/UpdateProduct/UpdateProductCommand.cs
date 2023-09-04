using MediatR;

namespace Nograd.ProductService.Commands.Features.UpdateProduct;

public sealed class UpdateProductCommand : IRequest
{
    public UpdateProductCommand(
        string name,
        string description,
        string category,
        decimal price,
        Guid productId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
        if (string.IsNullOrWhiteSpace(category)) throw new ArgumentNullException(nameof(category));
        if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));
        if (productId == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(productId));

        Name = name;
        Description = description;
        Category = category;
        Price = price;
        ProductId = productId;
    }

    public string Name { get; }
    public string Description { get; }
    public string Category { get; }
    public decimal Price { get; }
    public Guid ProductId { get; }
}