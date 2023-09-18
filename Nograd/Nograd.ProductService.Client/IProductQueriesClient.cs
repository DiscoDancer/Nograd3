using Nograd.ProductService.Queries.WepApi.Features.GetProductById.Controllers;

namespace Nograd.ProductService.Queries.Client;

public interface IProductQueriesClient
{
    Task<GetProductByIdExportProduct?> GetProductByIdOrDefaultAsync(Guid id);
}