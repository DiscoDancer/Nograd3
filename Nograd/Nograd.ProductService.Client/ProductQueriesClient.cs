using Nograd.ProductService.Queries.WepApi.Features.EnsureProductsExist.Controllers;
using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts.Controllers;
using Nograd.ProductService.Queries.WepApi.Features.GetProductById.Controllers;
using RestSharp;

namespace Nograd.ProductService.Queries.Client;

public sealed class ProductQueriesClient : IProductQueriesClient
{
    private readonly RestClient _restClient;

    public ProductQueriesClient(string baseUrl)
    {
        if (string.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));

        _restClient = new RestClient(new RestClientOptions(baseUrl));
    }

    public async Task<GetProductByIdExportProduct?> GetProductByIdOrDefaultAsync(Guid productId)
    {
        if (productId == Guid.Empty) throw new ArgumentNullException(nameof(productId));

        var request = new RestRequest($"/{GetProductByIdRoutes.ControllerRoute}/{GetProductByIdRoutes.ActionRoute}");
        request.AddParameter(nameof(productId), productId);

        var response = await _restClient.ExecuteAsync<GetProductByIdExportProduct?>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to GetProductById");
        }

        return response.Data;
    }

    public async Task<GetAllProductsOutput> GetAllProductsAsync(int? take = null, int? skip = null, string? category = null)
    {
        var request = new RestRequest($"/{GetAllProductsRoutes.ControllerRoute}/{GetAllProductsRoutes.ActionRoute}");
        if (take != null) request.AddParameter(nameof(take), take.Value);
        if (skip != null) request.AddParameter(nameof(skip), skip.Value);
        if (!string.IsNullOrWhiteSpace(category)) request.AddParameter(nameof(category), category);

        var response = await _restClient.ExecuteAsync<GetAllProductsOutput?>(request);

        if (!response.IsSuccessStatusCode || response.Data == null)
        {
            throw new Exception("Failed to GetAllProducts");
        }

        return response.Data;
    }

    public async Task<bool> EnsureProductsExistAsync(IReadOnlyCollection<Guid> productIds)
    {
        if (productIds == null || !productIds.Any()) throw new ArgumentNullException(nameof(productIds));


        var request = new RestRequest($"/{EnsureProductsExistRoutes.ControllerRoute}/{EnsureProductsExistRoutes.ActionRoute}", Method.Post);
        request.AddBody(productIds);

        var response = await _restClient.ExecuteAsync<bool>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to EnsureProductsExist");
        }

        return response.Data;
    }


}