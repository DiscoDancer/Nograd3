using Nograd.OrderService.Queries.Persistence.Entities;
using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Mappers;

public sealed class GetAllOrdersMapper : IGetAllOrdersMapper
{
    public GetAllOrdersControllerOutputOrder Map(OrderEntity order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (string.IsNullOrWhiteSpace(order.CustomerAddress))
            throw new ArgumentNullException(nameof(order.CustomerAddress));
        if (string.IsNullOrWhiteSpace(order.CustomerName)) throw new ArgumentNullException(nameof(order.CustomerName));
        if (order.OrderId == Guid.Empty) throw new ArgumentNullException(nameof(order.OrderId));
        if (order.ProductQuantities == null || order.ProductQuantities.Count == 0 ||
            order.ProductQuantities.Any(x => x.Quantity <= 0))
            throw new ArgumentNullException(nameof(order.ProductQuantities));

        var productQuantities = order
            .ProductQuantities
            .Select(x => new GetAllOrdersControllerOutputProductQuantity(Map(x.Product), x.Quantity))
            .ToList();

        return new GetAllOrdersControllerOutputOrder(
            order.OrderId,
            productQuantities: productQuantities,
            customerName: order.CustomerName,
            customerAddress: order.CustomerAddress,
            isGift: order.IsGift,
            isShipped: order.IsShipped);
    }

    private GetAllOrdersControllerOutputProduct Map(ProductEntity product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (string.IsNullOrWhiteSpace(product.Name)) throw new ArgumentNullException(nameof(product.Name));
        if (string.IsNullOrWhiteSpace(product.Description))
            throw new ArgumentNullException(nameof(product.Description));
        if (string.IsNullOrWhiteSpace(product.Category)) throw new ArgumentNullException(nameof(product.Category));
        if (product.Price <= 0) throw new ArgumentNullException(nameof(product.Price));
        if (product.ProductId == Guid.Empty) throw new ArgumentNullException(nameof(product.ProductId));

        return new GetAllOrdersControllerOutputProduct(
            product.Name,
            category: product.Category,
            description: product.Description,
            productId: product.ProductId,
            price: product.Price);
    }
}