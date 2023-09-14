namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

public sealed class GetAllOrdersExportOrderProductQuantity
{
    public GetAllOrdersExportOrderProductQuantity(Guid productId, int quantity)
    {
        if (productId == Guid.Empty) throw new ArgumentException(nameof(productId));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        ProductId = productId;
        Quantity = quantity;
    }


    public Guid ProductId { get; }
    public int Quantity { get; }
}