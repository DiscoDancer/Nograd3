using Nograd.OrderService.Commands.Features.CreateOrder.Controllers;
using Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

namespace Nograd.OrderService.Commands.Client;

public interface IOrderCommandsClient
{
    public Task<CreateOrderControllerOutput> CreateOrderAsync(CreateOrderControllerInput input);
    public Task<UpdateOrderControllerOutput> UpdateOrderAsync(UpdateOrderControllerInput input);
}