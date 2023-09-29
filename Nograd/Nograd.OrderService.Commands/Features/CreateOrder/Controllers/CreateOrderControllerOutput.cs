namespace Nograd.OrderService.Commands.Features.CreateOrder.Controllers;

[Serializable]
public sealed class CreateOrderControllerOutput
{
    public CreateOrderControllerOutput(Guid id, string message)
    {
        if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));

        OrderId = id;
        Message = message;
    }


    public CreateOrderControllerOutput()
    {

    }

    public Guid? OrderId { get; set; }
    public string? Message { get; set; }
}