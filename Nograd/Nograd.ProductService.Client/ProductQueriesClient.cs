using System.Net;
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

        var response = await _restClient.ExecuteAsync<GetProductByIdExportProduct>(request);
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        return response.Data;
    }
}