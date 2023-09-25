using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Controllers;
using Nograd.ProductService.Queries.WepApi.Features.GetProductById.Controllers;

namespace Nograd.ProductService.Queries.Client;

public interface IProductQueriesClient
{
    Task<GetProductByIdExportProduct?> GetProductByIdOrDefaultAsync(Guid id);
    Task<bool> EnsureProductsExistAsync(IReadOnlyCollection<Guid> productIds);
    Task<GetAllProductsOutput> GetAllProductsAsync(
        int? take = null,
        int? skip = null,
        string? category = null);
}