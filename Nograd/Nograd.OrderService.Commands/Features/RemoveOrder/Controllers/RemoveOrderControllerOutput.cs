namespace Nograd.OrderService.Commands.Features.RemoveOrder.Controllers;

public sealed class RemoveOrderControllerOutput
{
    public RemoveOrderControllerOutput(Guid? id, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

        OrderId = id;
        Message = message;
    }

    public Guid? OrderId { get; }
    public string Message { get; }
}