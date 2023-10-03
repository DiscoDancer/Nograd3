namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

[Serializable]
public sealed class GetAllOrdersControllerOutputProductQuantity
{
    public GetAllOrdersControllerOutputProductQuantity(GetAllOrdersControllerOutputProduct product, int quantity)
    {
        if (product == null) throw new ArgumentException(nameof(product));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        Product = product;
        Quantity = quantity;
    }

    public GetAllOrdersControllerOutputProductQuantity()
    {

    }

    public GetAllOrdersControllerOutputProduct? Product { get; set; }
    public int? Quantity { get; set; }
}