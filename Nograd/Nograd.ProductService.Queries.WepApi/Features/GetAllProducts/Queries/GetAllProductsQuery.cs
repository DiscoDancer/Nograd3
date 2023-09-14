using MediatR;
using Nograd.ProductService.Queries.Persistence.Entities;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Queries;

public sealed record GetAllProductsQuery : IRequest<IEnumerable<ProductEntity>>;