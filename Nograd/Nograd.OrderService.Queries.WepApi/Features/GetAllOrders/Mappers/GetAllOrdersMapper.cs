using Nograd.OrderService.Queries.Persistence.Entities;
using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Mappers;

public sealed class GetAllOrdersMapper : IGetAllOrdersMapper
{
    public GetAllOrdersExportOrder Map(OrderEntity order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (string.IsNullOrWhiteSpace(order.CustomerAddress)) throw new ArgumentNullException(nameof(order.CustomerAddress));
        if (string.IsNullOrWhiteSpace(order.CustomerName)) throw new ArgumentNullException(nameof(order.CustomerName));
        if (order.OrderId == Guid.Empty) throw new ArgumentNullException(nameof(order.OrderId));
        if (order.ProductQuantities == null || order.ProductQuantities.Count == 0 || order.ProductQuantities.Any(x => x.ProductId == Guid.Empty || x.Quantity <= 0))
            throw new ArgumentNullException(nameof(order.ProductQuantities));

        var productQuantities = order
            .ProductQuantities
            .Select(x => new GetAllOrdersExportOrderProductQuantity(x.ProductId, x.Quantity))
            .ToList();

        return new GetAllOrdersExportOrder(
            orderId: order.OrderId,
            productQuantities: productQuantities,
            customerName: order.CustomerName,
            customerAddress: order.CustomerAddress,
            isGift: order.IsGift,
            isShipped: order.IsShipped);
    }
}