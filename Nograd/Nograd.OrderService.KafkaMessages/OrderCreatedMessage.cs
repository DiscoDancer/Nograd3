using System.Text.Json.Serialization;

namespace Nograd.OrderService.KafkaMessages;

public sealed class OrderCreatedMessage : OrderBaseMessage
{
    public OrderCreatedMessage(
        string customerName,
        string customerAddress,
        bool isShipped,
        bool isGift,
        Guid orderId,
        IReadOnlyCollection<OrderCreatedMessageProductQuantity> productQuantities)
    {
        CustomerName = customerName;
        CustomerAddress = customerAddress;
        IsShipped = isShipped;
        IsGift = isGift;
        OrderId = orderId;
        ProductQuantities = productQuantities;
        TypeName = nameof(OrderCreatedMessage);
    }

    [JsonConstructor]
    public OrderCreatedMessage()
    {
    }

    public Guid? OrderId { get; set; }
    public bool? IsShipped { get; set; }
    public bool? IsGift { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; }
    public IReadOnlyCollection<OrderCreatedMessageProductQuantity>? ProductQuantities { get; set; }
}

