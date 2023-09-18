using MediatR;
using Nograd.ProductService.Queries.Persistence.Entities;
using Nograd.ProductService.Queries.Persistence.Repositories;

namespace Nograd.ProductService.Queries.WepApi.Features.GetProductById.Queries;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductEntity?>
{
    private readonly IReadProductRepository _productRepository;

    public GetProductByIdHandler(IReadProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<ProductEntity?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByIdAsync(request.ProductId);
    }
}