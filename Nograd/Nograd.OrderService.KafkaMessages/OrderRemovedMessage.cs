using System.Text.Json.Serialization;

namespace Nograd.OrderService.KafkaMessages;

public sealed class OrderRemovedMessage : OrderBaseMessage
{
    public OrderRemovedMessage(Guid orderId)
    {
        OrderId = orderId;
        TypeName = nameof(OrderRemovedMessage);
    }

    [JsonConstructor]
    public OrderRemovedMessage()
    {
    }

    public Guid? OrderId { get; set; }
}