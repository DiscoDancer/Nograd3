using Nograd.OrderService.Commands.Features.CreateOrder.Commands;
using Nograd.OrderService.Commands.Features.CreateOrder.Controllers;

namespace Nograd.OrderService.Commands.Features.CreateOrder.Mappers
{
    public interface ICreateOrderControllerInputToCommandMapper
    {
        CreateOrderCommand Map(CreateOrderControllerInput input, Guid orderId);
    }
}
