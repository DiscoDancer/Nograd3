using MediatR;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Queries;

public sealed record GetAllProductsQuery(
        int Take = 100,
        int Skip = 0,
        string? Category = null)
    : IRequest<GetAllProductsQueryOutput>;