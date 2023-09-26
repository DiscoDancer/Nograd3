using MediatR;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllCategories.Queries;

public sealed record GetAllCategoriesQuery : IRequest<IReadOnlyCollection<string>>;