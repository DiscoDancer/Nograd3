using MediatR;

namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    public sealed class CreateProductHandler: IRequestHandler<CreateProductCommand>
    {
        public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
