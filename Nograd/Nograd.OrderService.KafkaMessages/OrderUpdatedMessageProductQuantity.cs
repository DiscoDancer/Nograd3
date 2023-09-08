namespace Nograd.OrderService.KafkaMessages;

public sealed class OrderUpdatedMessageProductQuantity
{
    public Guid? ProductId { get; set; }
    public int? Quantity { get; set; }
}