using MediatR;
using Nograd.ProductService.Commands.Domain;

namespace Nograd.ProductService.Commands.Features.RemoveProduct
{
    public sealed class RemoveProductCommandHandler: IRequestHandler<RemoveProductCommand>
    {
        private readonly IEventStore _eventStore;

        public RemoveProductCommandHandler(IEventStore store)
        {
            _eventStore = store ?? throw new ArgumentNullException(nameof(store));
        }

        public async Task Handle(RemoveProductCommand command, CancellationToken cancellationToken)
        {
            var events = await _eventStore.GetEventsAsync(command.ProductId);
            var product = EventApplicator.RestoreFromEvents(events);

            var productRemovedEvent = Domain.ProductEventProducer.Remove(product);

            await _eventStore.SaveEventAsync(productRemovedEvent, product.Id);
            // push event to kafka

            throw new NotImplementedException();
        }
    }
}
