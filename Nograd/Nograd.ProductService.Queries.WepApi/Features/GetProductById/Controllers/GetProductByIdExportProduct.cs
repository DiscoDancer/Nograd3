namespace Nograd.ProductService.Queries.WepApi.Features.GetProductById.Controllers;

public sealed class GetProductByIdExportProduct
{
    public GetProductByIdExportProduct(
        string name,
        string description,
        string category,
        Guid productId,
        decimal price
    )
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
        if (string.IsNullOrWhiteSpace(category)) throw new ArgumentNullException(nameof(category));
        if (productId == Guid.Empty) throw new ArgumentNullException(nameof(productId));
        if (price <= 0) throw new ArgumentNullException(nameof(price));

        Name = name;
        Description = description;
        Category = category;
        Price = price;
        ProductId = productId;
    }

    public string Name { get; }
    public string Description { get; }
    public Guid ProductId { get; }
    public string Category { get; }
    public decimal Price { get; }
}