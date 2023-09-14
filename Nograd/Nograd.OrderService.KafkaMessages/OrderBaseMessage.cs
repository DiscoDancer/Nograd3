namespace Nograd.OrderService.KafkaMessages;

public abstract class OrderBaseMessage
{
    public string? TypeName { get; set; }
}