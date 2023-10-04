namespace Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

[Serializable]
public sealed class UpdateOrderControllerInputProductQuantity
{
    public Guid? ProductId { get; set; }
    public int? Quantity { get; set; }
}