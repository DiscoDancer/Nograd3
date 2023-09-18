using MediatR;
using Nograd.ProductService.Queries.Persistence.Entities;

namespace Nograd.ProductService.Queries.WepApi.Features.GetProductById.Queries;

public sealed record GetProductByIdQuery (Guid ProductId) : IRequest<ProductEntity?>;