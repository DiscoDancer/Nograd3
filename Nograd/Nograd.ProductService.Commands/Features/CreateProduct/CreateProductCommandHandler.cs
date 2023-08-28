using MediatR;
using Nograd.ProductService.Commands.Domain;

namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    public sealed class CreateProductCommandHandler: IRequestHandler<CreateProductCommand>
    {
        public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productId = Guid.NewGuid();
            var productCreatedEvent = CreateProductDomainService.Create(
                name: request.Name,
                description: request.Description,
                category: request.Category,
                price: request.Price,
                productId: productId);
            var product = Product.Create(productCreatedEvent);

            // todo push to kafka
            // todo save to mongo

            throw new NotImplementedException();
        }
    }
}
