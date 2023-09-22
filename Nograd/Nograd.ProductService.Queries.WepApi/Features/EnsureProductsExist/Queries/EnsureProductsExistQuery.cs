using MediatR;

namespace Nograd.ProductService.Queries.WepApi.Features.EnsureProductsExist.Queries;

public sealed record EnsureProductsExistQuery(IReadOnlyCollection<Guid> ProductIds) : IRequest<bool>;