namespace Nograd.OrderService.Commands.Features.CreateOrder
{
    public sealed class CreateOrderControllerInputProductQuantity
    {
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
