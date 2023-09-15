namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

public sealed class GetAllOrdersExportOrderProductQuantity
{
    public GetAllOrdersExportOrderProductQuantity(GetAllOrdersExportProduct product, int quantity)
    {
        if (product == null) throw new ArgumentException(nameof(product));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        Product = product;
        Quantity = quantity;
    }


    public GetAllOrdersExportProduct Product { get; }
    public int Quantity { get; }
}