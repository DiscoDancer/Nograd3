using MediatR;
using Nograd.ProductService.Queries.Persistence.Repositories;

namespace Nograd.ProductService.Queries.WepApi.Features.EnsureProductsExist.Queries;

public sealed class EnsureProductsExistHandler : IRequestHandler<EnsureProductsExistQuery, bool>
{
    private readonly IReadProductRepository _productRepository;

    public EnsureProductsExistHandler(IReadProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<bool> Handle(EnsureProductsExistQuery request, CancellationToken cancellationToken)
    {
        foreach (var productId in request.ProductIds)
        {
            var foundProduct = await _productRepository.GetByIdAsync(productId);
            if (foundProduct == null)
            {
                return false;
            }
        }

        return true;
    }
}