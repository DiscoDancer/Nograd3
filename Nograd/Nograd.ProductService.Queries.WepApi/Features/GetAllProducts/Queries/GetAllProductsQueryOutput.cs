using Nograd.ProductService.Queries.Persistence.Entities;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Queries;

public sealed record GetAllProductsQueryOutput(
    IReadOnlyCollection<ProductEntity> Products,
    int TotalCountWithSelectedCategory);