namespace Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

public sealed class UpdateOrderControllerInputProductQuantity
{
    public Guid? ProductId { get; set; }
    public int? Quantity { get; set; }
}