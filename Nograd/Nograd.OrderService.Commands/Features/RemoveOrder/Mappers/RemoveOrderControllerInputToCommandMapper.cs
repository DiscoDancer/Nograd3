using Nograd.OrderService.Commands.Features.RemoveOrder.Commands;
using Nograd.OrderService.Commands.Features.RemoveOrder.Controllers;

namespace Nograd.OrderService.Commands.Features.RemoveOrder.Mappers
{
    public sealed class RemoveOrderControllerInputToCommandMapper: IRemoveOrderControllerInputToCommandMapper
    {
        public RemoveOrderCommand Map(RemoveOrderControllerInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (input.OrderId == null || input.OrderId == Guid.Empty)
                throw new ArgumentNullException(nameof(input.OrderId));

            return new RemoveOrderCommand(input.OrderId.Value);
        }
    }
}
