using MediatR;
using Nograd.ProductService.Commands.Domain;

namespace Nograd.ProductService.Commands.Features.UpdateProduct
{
    public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IEventStore _eventStore;

        public UpdateProductCommandHandler(IEventStore store)
        {
            _eventStore = store ?? throw new ArgumentNullException(nameof(store));
        }

        public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var events = await _eventStore.GetEventsAsync(command.ProductId);
            var product = EventApplicator.RestoreFromEvents(events);

            var productUpdatedEvent = Domain.ProductEventProducer.Update(
                product: product,
                name: command.Name,
                description: command.Description,
                category: command.Category,
                price: command.Price);

            await _eventStore.SaveEventAsync(productUpdatedEvent, product.Id);
            // push event to kafka

            throw new NotImplementedException();
        }
    }
}
