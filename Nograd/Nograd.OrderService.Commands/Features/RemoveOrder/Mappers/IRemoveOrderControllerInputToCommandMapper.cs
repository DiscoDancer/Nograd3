using Nograd.OrderService.Commands.Features.RemoveOrder.Commands;
using Nograd.OrderService.Commands.Features.RemoveOrder.Controllers;

namespace Nograd.OrderService.Commands.Features.RemoveOrder.Mappers;

public interface IRemoveOrderControllerInputToCommandMapper
{
    RemoveOrderCommand Map(RemoveOrderControllerInput input);
}