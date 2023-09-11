using MediatR;

namespace Nograd.OrderService.Commands.Features.RemoveOrder.Commands;

public sealed class RemoveOrderCommand : IRequest
{
    public RemoveOrderCommand(Guid orderId)
    {
        if (orderId == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(orderId));

        OrderId = orderId;
    }

    public Guid OrderId { get; }
}