using Nograd.OrderService.Commands.Features.UpdateOrder.Commands;
using Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

namespace Nograd.OrderService.Commands.Features.UpdateOrder.Mappers;

public interface IUpdateOrderControllerInputToCommandMapper
{
    UpdateOrderCommand Map(UpdateOrderControllerInput input);
}