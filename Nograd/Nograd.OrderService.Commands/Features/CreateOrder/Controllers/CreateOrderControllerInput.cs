namespace Nograd.OrderService.Commands.Features.CreateOrder.Controllers
{
    public sealed class CreateOrderControllerInput
    {
        public Guid? Id { get; set; }
        public bool? IsShipped { get; set; }
        public bool? IsGift { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public IReadOnlyCollection<CreateOrderControllerInputProductQuantity>? ProductQuantities { get; set; }
    }
}
