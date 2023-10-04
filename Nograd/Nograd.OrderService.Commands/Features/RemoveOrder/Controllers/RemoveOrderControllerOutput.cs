namespace Nograd.OrderService.Commands.Features.RemoveOrder.Controllers;

[Serializable]
public sealed class RemoveOrderControllerOutput
{
    public RemoveOrderControllerOutput(Guid? id, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

        OrderId = id;
        Message = message;
    }

    public RemoveOrderControllerOutput()
    {

    }

    public Guid? OrderId { get; set; }
    public string? Message { get; set; }
}