namespace Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Controllers;

[Serializable]
public sealed class GetOrderByIdControllerOutputProductQuantity
{
    public GetOrderByIdControllerOutputProductQuantity(GetOrderByIdControllerOutputProduct product, int quantity)
    {
        if (product == null) throw new ArgumentException(nameof(product));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        Product = product;
        Quantity = quantity;
    }

    public GetOrderByIdControllerOutputProductQuantity()
    {
    }

    public GetOrderByIdControllerOutputProduct? Product { get; set; }
    public int? Quantity { get; set; }
}