namespace Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

[Serializable]
public sealed class UpdateOrderControllerOutput
{
    public UpdateOrderControllerOutput(Guid? id, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

        OrderId = id;
        Message = message;
    }

    public UpdateOrderControllerOutput()
    {

    }

    public Guid? OrderId { get; set; }
    public string? Message { get; set; }
}