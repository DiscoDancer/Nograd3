using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Domain.Events;
using Nograd.OrderService.KafkaMessages;

namespace Nograd.OrderService.Commands.Infrastructure.EventNotifications;

public sealed class EventToMessageMapper : IEventToMessageMapper
{
    public OrderBaseMessage Map(BaseEvent @event)
    {
        return @event switch
        {
            OrderCreatedEvent ev => new OrderCreatedMessage(
                customerAddress: ev.CustomerAddress,
                customerName: ev.CustomerName,
                isGift: ev.IsGift,
                isShipped: ev.IsShipped,
                orderId: ev.OrderId,
                productQuantities: ev.ProductQuantities.Select(x => new OrderCreatedMessageProductQuantity
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                }).ToArray()),

            OrderUpdatedEvent ev => new OrderUpdatedMessage(
                customerAddress: ev.CustomerAddress,
                customerName: ev.CustomerName,
                isGift: ev.IsGift,
                isShipped: ev.IsShipped,
                orderId: ev.OrderId,
                productQuantities: ev.ProductQuantities.Select(x => new OrderUpdatedMessageProductQuantity
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                }).ToArray()),

            OrderRemovedEvent ev => new OrderRemovedMessage(ev.OrderId),

            _ => throw new NotImplementedException()
        };
    }
}