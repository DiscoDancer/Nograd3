using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;
using Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Controllers;
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

    public async Task<GetOrderByIdControllerOutputOrder?> GetOrderByIdOrDefaultAsync(Guid orderId)
    {
        if (orderId == Guid.Empty) throw new ArgumentNullException(nameof(orderId));

        var request = new RestRequest($"/{GetOrderByIdControllerRoutes.ControllerRoute}/{GetOrderByIdControllerRoutes.ActionRoute}");
        request.AddParameter(nameof(orderId), orderId);

        var response = await _restClient.ExecuteAsync<GetOrderByIdControllerOutputOrder?>(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to execute a client request to controller action GetOrderByIdOrDefaultAsync.");
        }

        return response.Data;
    }
}