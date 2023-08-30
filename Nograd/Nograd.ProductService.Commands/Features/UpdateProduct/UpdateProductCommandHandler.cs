using MediatR;
using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Commands.Infrastructure.EventStore;

namespace Nograd.ProductService.Commands.Features.UpdateProduct
{
    public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IEventStore _eventStore;

        public UpdateProductCommandHandler(IEventStore store)
        {
            _eventStore = store ?? throw new ArgumentNullException(nameof(store));
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var events = await _eventStore.GetEventsAsync(request.ProductId);
            var product = Product.GetNotCreatedProduct();
            foreach (var @event in events)
            {
                product = EventApplicator.ApplyEvent(product, @event);
            }

            var productUpdatedEvent = ProductDomainService.Update(
                product: product,
                name: request.Name,
                description: request.Description,
                category: request.Category,
                price: request.Price);

            await _eventStore.SaveEventAsync(productUpdatedEvent, product.Id);
            // push event to kafka

            throw new NotImplementedException();
        }
    }
}
