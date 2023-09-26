using MediatR;
using Nograd.ProductService.Queries.Persistence.Repositories;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllCategories.Queries;

public sealed class GetAllCategoriesHandler: IRequestHandler<GetAllCategoriesQuery, IReadOnlyCollection<string>>
{
    private readonly IReadProductRepository _productRepository;

    public GetAllCategoriesHandler(IReadProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<IReadOnlyCollection<string>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _productRepository.GetAllCategoriesAsync();
        return categories;
    }
}