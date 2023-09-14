using System.Text.Json.Serialization;

namespace Nograd.OrderService.KafkaMessages;

public sealed class OrderUpdatedMessage : OrderBaseMessage
{
    public OrderUpdatedMessage(
        string customerName,
        string customerAddress,
        bool isShipped,
        bool isGift,
        Guid orderId,
        IReadOnlyCollection<OrderUpdatedMessageProductQuantity> productQuantities)
    {
        CustomerName = customerName;
        CustomerAddress = customerAddress;
        IsShipped = isShipped;
        IsGift = isGift;
        OrderId = orderId;
        ProductQuantities = productQuantities;
        TypeName = nameof(OrderUpdatedMessage);
    }

    [JsonConstructor]
    public OrderUpdatedMessage()
    {
    }

    public Guid? OrderId { get; set; }
    public bool? IsShipped { get; set; }
    public bool? IsGift { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; }
    public IReadOnlyCollection<OrderUpdatedMessageProductQuantity>? ProductQuantities { get; set; }
}