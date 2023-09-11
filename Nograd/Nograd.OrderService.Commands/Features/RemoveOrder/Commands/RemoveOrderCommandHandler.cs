using MediatR;
using Nograd.OrderService.Commands.Domain;

namespace Nograd.OrderService.Commands.Features.RemoveOrder.Commands
{
    public sealed class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand>
    {
        private readonly IEventStore _eventStore;
        private readonly IOrderEventHandlingStrategy _eventHandlingStrategy;

        public RemoveOrderCommandHandler(
            IEventStore store,
            IOrderEventHandlingStrategy eventHandlingStrategy)
        {
            _eventStore = store ?? throw new ArgumentNullException(nameof(store));
            _eventHandlingStrategy =
                eventHandlingStrategy ?? throw new ArgumentNullException(nameof(eventHandlingStrategy));
        }

        public async Task Handle(RemoveOrderCommand command, CancellationToken cancellationToken)
        {
            var events = await _eventStore.GetEventsAsync(command.OrderId);
            var order = EventApplicator.RestoreFromEvents(events);
            var productRemovedEvent = OrderEventProducer.Remove(order);

            await _eventHandlingStrategy.HandleAsync(productRemovedEvent, productRemovedEvent.OrderId);
        }
    }
}
