using Nograd.ProductService.Commands.Features.CreateProduct.Controllers;
using Nograd.ProductService.Commands.Features.RemoveProduct.Controllers;
using Nograd.ProductService.Commands.Features.UpdateProduct.Controllers;
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
            throw new Exception("Client failed to execute RemoveProductAsync request to controller.");
        }

        return response.Data;
    }

    public async Task<CreateProductControllerOutput> CreateProductAsync(CreateProductControllerInput input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        var request =
            new RestRequest(
                $"/{CreateProductControllerRoutes.ControllerRoute}/{CreateProductControllerRoutes.ActionRoute}",
                Method.Post);
        request.AddBody(input);

        var response = await _restClient.ExecuteAsync<CreateProductControllerOutput>(request);

        if (!response.IsSuccessStatusCode || response.Data == null)
        {
            throw new Exception("Client failed to execute CreateProductAsync request to controller.");
        }

        return response.Data;
    }

    public async Task<UpdateProductControllerOutput> UpdateProductAsync(UpdateProductControllerInput input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        var request =
            new RestRequest(
                $"/{UpdateProductControllerRoutes.ControllerRoute}/{UpdateProductControllerRoutes.ActionRoute}",
                Method.Put);
        request.AddBody(input);

        var response = await _restClient.ExecuteAsync<UpdateProductControllerOutput>(request);

        if (!response.IsSuccessStatusCode || response.Data == null)
        {
            throw new Exception("Client failed to execute UpdateProductAsync request to controller.");
        }

        return response.Data;
    }
}