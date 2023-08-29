using MediatR;
using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Commands.Infrastructure.EventStore;
using Nograd.ProductService.Events;

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

            if (!events.Any())
            {
                throw new Exception("Not possible to find any events");
            }

            var firstEvent = events.First() as ProductCreatedEvent;
            if (firstEvent == null)
            {
                throw new Exception("The first event should be always create event.");
            }

            var product = Product.Create(firstEvent);
            var i = 1;
            for (; i < events.Count(); i++)
            {
                EventApplicator.ApplyEvent(product, events[i]);
            }

            var productUpdatedEvent = ProductDomainService.Update(
                product: product,
                name: request.Name,
                description: request.Description,
                category: request.Category,
                price: request.Price);

            await _eventStore.SaveEventAsync(productUpdatedEvent);
            // push event to kafka

            throw new NotImplementedException();
        }
    }
}
