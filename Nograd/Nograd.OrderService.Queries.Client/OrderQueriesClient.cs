using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;
using RestSharp;

namespace Nograd.OrderService.Queries.Client;

public sealed class OrderQueriesClient : IOrderQueriesClient
{
    private readonly RestClient _restClient;

    public OrderQueriesClient(string baseUrl)
    {
        if (string.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));

        _restClient = new RestClient(new RestClientOptions(baseUrl));
    }

    public async Task<GetAllOrdersControllerOutput> GetAllOrdersAsync()
    {
        var request = new RestRequest($"/{GetAllOrdersControllerRoutes.ControllerRoute}/{GetAllOrdersControllerRoutes.ActionRoute}");

        var response = await _restClient.ExecuteAsync<GetAllOrdersControllerOutput?>(request);

        if (!response.IsSuccessStatusCode || response.Data == null)
        {
            throw new Exception("Failed to execute a client request to controller action GetAllOrdersAsync.");
        }

        return response.Data;
    }
}