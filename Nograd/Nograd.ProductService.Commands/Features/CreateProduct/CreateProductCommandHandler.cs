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
            var product = Product.GetNotCreatedProduct();
            var productCreatedEvent = Domain.ProductEventProducer.Create(
                product: product,
                name: request.Name,
                description: request.Description,
                category: request.Category,
                price: request.Price,
                productId: productId);

            _eventStore.SaveEventAsync(productCreatedEvent, productId);

            // todo push to kafka


            throw new NotImplementedException();
        }
    }
}
