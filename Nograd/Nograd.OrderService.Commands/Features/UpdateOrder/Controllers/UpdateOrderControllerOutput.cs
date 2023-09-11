namespace Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

public sealed class UpdateOrderControllerOutput
{
    public UpdateOrderControllerOutput(Guid? id, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

        OrderId = id;
        Message = message;
    }

    public Guid? OrderId { get; }
    public string Message { get; }
}