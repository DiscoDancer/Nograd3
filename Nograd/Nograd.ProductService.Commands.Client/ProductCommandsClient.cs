using Nograd.ProductService.Commands.Features.RemoveProduct.Controllers;
using RestSharp;

namespace Nograd.ProductService.Commands.Client;

public sealed class ProductCommandsClient : IProductCommandsClient
{
    private readonly RestClient _restClient;

    public ProductCommandsClient(string baseUrl)
    {
        if (string.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));

        _restClient = new RestClient(new RestClientOptions(baseUrl));
    }

    public async Task<RemoveProductControllerOutput> RemoveProductAsync(RemoveProductControllerInput input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        var request =
            new RestRequest(
                $"/{RemoveProductControllerRoutes.ControllerRoute}/{RemoveProductControllerRoutes.ActionRoute}",
                Method.Delete);
        request.AddBody(input);

        var response = await _restClient.ExecuteAsync<RemoveProductControllerOutput>(request);

        if (!response.IsSuccessStatusCode || response.Data == null)
        {
            throw new Exception("Failed to RemoveProductAsync");
        }

        return response.Data;
    }
}