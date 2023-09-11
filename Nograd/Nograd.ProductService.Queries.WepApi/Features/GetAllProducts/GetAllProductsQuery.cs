using MediatR;
using Nograd.ProductService.Queries.Persistence.Entities;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts;

public sealed record GetAllProductsQuery : IRequest<IEnumerable<ProductEntity>>;