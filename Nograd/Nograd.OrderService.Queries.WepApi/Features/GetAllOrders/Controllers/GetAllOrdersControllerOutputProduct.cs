namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

[Serializable]
public sealed class GetAllOrdersControllerOutputProduct
{
    public GetAllOrdersControllerOutputProduct(
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

    public GetAllOrdersControllerOutputProduct()
    {

    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? ProductId { get; set; }
    public string? Category { get; set; }
    public decimal? Price { get; set; }
}