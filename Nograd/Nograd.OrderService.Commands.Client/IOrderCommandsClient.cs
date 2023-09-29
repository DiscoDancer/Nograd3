using Nograd.OrderService.Commands.Features.CreateOrder.Controllers;

namespace Nograd.OrderService.Commands.Client;

public interface IOrderCommandsClient
{
    public Task<CreateOrderControllerOutput> CreateOrderAsync(CreateOrderControllerInput input);
}