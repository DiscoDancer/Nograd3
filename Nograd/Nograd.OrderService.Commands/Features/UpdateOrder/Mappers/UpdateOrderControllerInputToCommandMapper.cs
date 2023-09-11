using Nograd.OrderService.Commands.Features.UpdateOrder.Commands;
using Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

namespace Nograd.OrderService.Commands.Features.UpdateOrder.Mappers;

public sealed class UpdateOrderControllerInputToCommandMapper : IUpdateOrderControllerInputToCommandMapper
{
    public UpdateOrderCommand Map(UpdateOrderControllerInput input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (input.ProductQuantities == null) throw new ArgumentNullException(nameof(input.ProductQuantities));
        if (input.IsGift == null) throw new ArgumentNullException(nameof(input.IsGift));
        if (input.IsShipped == null) throw new ArgumentNullException(nameof(input.IsShipped));
        if (string.IsNullOrWhiteSpace(input.CustomerAddress))
            throw new ArgumentNullException(nameof(input.CustomerAddress));
        if (string.IsNullOrWhiteSpace(input.CustomerName)) throw new ArgumentNullException(nameof(input.CustomerName));
        if (input.Id == null || input.Id == Guid.Empty) throw new ArgumentNullException(nameof(input.Id));

        return new UpdateOrderCommand(
            input.ProductQuantities.Select(Map).ToArray(),
            input.IsShipped.Value,
            input.IsGift.Value,
            customerAddress: input.CustomerAddress,
            customerName: input.CustomerName,
            orderId: input.Id.Value);
    }

    private UpdateOrderCommandProductQuantity Map(UpdateOrderControllerInputProductQuantity input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (input.ProductId == null || input.ProductId == Guid.Empty)
            throw new ArgumentNullException(nameof(input.ProductId));
        if (input.Quantity == null || input.Quantity <= 0) throw new ArgumentNullException(nameof(input.Quantity));

        return new UpdateOrderCommandProductQuantity(
            input.ProductId.Value,
            input.Quantity.Value);
    }
}