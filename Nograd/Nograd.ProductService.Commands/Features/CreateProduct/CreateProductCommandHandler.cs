using MediatR;
using Nograd.ProductService.Commands.Domain;

namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    public sealed class CreateProductCommandHandler: IRequestHandler<CreateProductCommand>
    {
        private readonly IEventStore _eventStore;

        public CreateProductCommandHandler(IEventStore store)
        {
            _eventStore = store ?? throw new ArgumentNullException(nameof(store));
        }

        public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productId = Guid.NewGuid();
            var productCreatedEvent = ProductDomainService.Create(
                name: request.Name,
                description: request.Description,
                category: request.Category,
                price: request.Price,
                productId: productId);
            var product = Product.Create(productCreatedEvent);

            _eventStore.SaveEventAsync(productCreatedEvent);

            // todo push to kafka


            throw new NotImplementedException();
        }
    }
}
