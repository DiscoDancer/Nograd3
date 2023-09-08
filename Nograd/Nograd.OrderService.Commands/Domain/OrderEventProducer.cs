using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Domain;

public static class OrderEventProducer
{
    public static OrderCreatedEvent Create(
        Order order,
        string customerName,
        string customerAddress,
        Guid orderId,
        bool isShipped,
        bool isGift,
        IReadOnlyCollection<OrderCreatedEventProductQuantity> productQuantities
    )
    {
        if (string.IsNullOrWhiteSpace(customerName)) throw new ArgumentNullException(nameof(customerName));
        if (string.IsNullOrWhiteSpace(customerAddress)) throw new ArgumentNullException(nameof(customerAddress));
        if (orderId == Guid.Empty) throw new ArgumentException(nameof(orderId));
        if (productQuantities == null || !productQuantities.Any())
            throw new ArgumentException(nameof(productQuantities));

        if (order.State != OrderLifecycleStates.ToBeCreated)
            throw new Exception($"Order with id {orderId} already has been created");

        return new OrderCreatedEvent(
            productQuantities,
            orderId,
            IsGift: isGift,
            IsShipped: isShipped,
            CustomerAddress: customerAddress,
            CustomerName: customerName);
    }

    public static OrderUpdatedEvent Update(
        Order order,
        string customerName,
        string customerAddress,
        Guid orderId,
        bool isShipped,
        bool isGift,
        IReadOnlyCollection<OrderUpdatedEventProductQuantity> productQuantities
    )
    {
        if (string.IsNullOrWhiteSpace(customerName)) throw new ArgumentNullException(nameof(customerName));
        if (string.IsNullOrWhiteSpace(customerAddress)) throw new ArgumentNullException(nameof(customerAddress));
        if (orderId == Guid.Empty) throw new ArgumentException(nameof(orderId));
        if (productQuantities == null || !productQuantities.Any())
            throw new ArgumentException(nameof(productQuantities));

        if (order.State != OrderLifecycleStates.Created)
            throw new Exception($"The order with id {order.Id} already has been removed or it is not yet created. So it can't be updated.");

        return new OrderUpdatedEvent(
            ProductQuantities: productQuantities,
            OrderId: orderId,
            IsGift: isGift,
            IsShipped: isShipped,
            CustomerAddress: customerAddress,
            CustomerName: customerName);
    }

    public static OrderRemovedEvent Remove(Order order)
    {
        if (order.Id == Guid.Empty) throw new ArgumentException(nameof(order.Id));

        if (order.State != OrderLifecycleStates.Created)
        {
            throw new Exception($"The Order with id {order.Id} already has been removed or it is not yet created. So it can't be removed.");
        }

        return new OrderRemovedEvent(order.Id);
    }
}