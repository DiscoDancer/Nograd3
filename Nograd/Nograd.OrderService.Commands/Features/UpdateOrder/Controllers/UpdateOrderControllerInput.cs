namespace Nograd.OrderService.Commands.Features.UpdateOrder.Controllers;

[Serializable]
public sealed class UpdateOrderControllerInput
{
    public Guid? Id { get; set; }
    public bool? IsShipped { get; set; }
    public bool? IsGift { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; }
    public IReadOnlyCollection<UpdateOrderControllerInputProductQuantity>? ProductQuantities { get; set; }
}