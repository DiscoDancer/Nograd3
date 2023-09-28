using Nograd.OrderService.Commands.Features.CreateOrder.Controllers;
using RestSharp;

namespace Nograd.OrderService.Commands.Client;

public sealed class OrderCommandsClient : IOrderCommandsClient
{
    private readonly RestClient _restClient;

    public OrderCommandsClient(string baseUrl)
    {
        if (string.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));

        _restClient = new RestClient(new RestClientOptions(baseUrl));
    }

    public async Task<CreateOrderControllerOutput> CreateOrderAsync(CreateOrderControllerInput input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        var request =
            new RestRequest($"/{CreateOrderControllerRoutes.ControllerRoute}/{CreateOrderControllerRoutes.ActionRoute}",
                Method.Post);
        request.AddBody(input);


        var response = await _restClient.ExecuteAsync<CreateOrderControllerOutput>(request);

        if (!response.IsSuccessStatusCode || response.Data == null)
        {
            throw new Exception("Failed to CreateOrderAsync");
        }

        return response.Data;
    }
}