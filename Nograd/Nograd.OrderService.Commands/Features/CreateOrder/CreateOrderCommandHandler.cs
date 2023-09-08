using MediatR;
using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Domain.Events;

namespace Nograd.OrderService.Commands.Features.CreateOrder
{
    public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderEventHandlingStrategy _eventHandlingStrategy;

        public CreateOrderCommandHandler(IOrderEventHandlingStrategy eventHandlingStrategy)
        {
            _eventHandlingStrategy = eventHandlingStrategy ?? throw new ArgumentNullException(nameof(eventHandlingStrategy));
        }

        public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = Order.GetNotCreatedOrder();

            var productQuantities = command.ProductQuantities
                .Select(x => new OrderCreatedEventProductQuantity(
                    ProductId: x.ProductId,
                    Quantity: x.Quantity))
                .ToArray();

            var orderCreatedEvent = OrderEventProducer.Create(
                order: order,
                customerName: command.CustomerName,
                customerAddress: command.CustomerAddress,
                orderId: command.OrderId,
                isGift: command.IsGift,
                isShipped: command.IsShipped,
                productQuantities: productQuantities);


            await _eventHandlingStrategy.HandleAsync(orderCreatedEvent, command.OrderId);
        }
    }
}
