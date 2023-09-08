namespace Nograd.OrderService.KafkaMessages;

public sealed class OrderCreatedMessageProductQuantity
{
    public Guid? ProductId { get; set; }
    public int? Quantity { get; set; }
}