namespace Nograd.OrderService.Commands.Features.RemoveOrder.Controllers;

[Serializable]
public sealed class RemoveOrderControllerInput
{
    public Guid? OrderId { get; set; }
}