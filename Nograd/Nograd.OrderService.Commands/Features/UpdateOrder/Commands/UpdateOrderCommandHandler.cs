using MediatR;
using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Features.UpdateOrder.Commands;

public sealed class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IEventStore _eventStore;
    private readonly IOrderEventHandlingStrategy _eventHandlingStrategy;

    public UpdateOrderCommandHandler(IEventStore store, IOrderEventHandlingStrategy eventHandlingStrategy)
    {
        _eventStore = store ?? throw new ArgumentNullException(nameof(store));
        _eventHandlingStrategy =
            eventHandlingStrategy ?? throw new ArgumentNullException(nameof(eventHandlingStrategy));
    }

    public async Task Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var events = await _eventStore.GetEventsAsync(command.OrderId);
        var order = EventApplicator.RestoreFromEvents(events);

        var productQuantities = command.ProductQuantities
            .Select(x => new OrderUpdatedEventProductQuantity(
                ProductId: x.ProductId,
                Quantity: x.Quantity))
            .ToArray();

        var productUpdatedEvent = OrderEventProducer.Update(
            order: order,
            customerName:command.CustomerName,
            customerAddress: command.CustomerAddress,
            orderId: command.OrderId,
            isGift: command.IsGift,
            isShipped: command.IsShipped,
            productQuantities: productQuantities);

        await _eventHandlingStrategy.HandleAsync(productUpdatedEvent, productUpdatedEvent.OrderId);
    }
}