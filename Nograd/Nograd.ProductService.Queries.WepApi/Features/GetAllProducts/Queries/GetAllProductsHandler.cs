using MediatR;
using Nograd.ProductService.Queries.Persistence.Repositories;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Queries;

public sealed class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsQueryOutput>
{
    private readonly IReadProductRepository _productRepository;

    public GetAllProductsHandler(IReadProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<GetAllProductsQueryOutput> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var totalCountWithSelectedCategory = await _productRepository.Count(request.Category);
        var products = await _productRepository.ListAllAsync(take: request.Take, skip: request.Skip, category: request.Category);

        return new GetAllProductsQueryOutput(products, totalCountWithSelectedCategory);
    }
}