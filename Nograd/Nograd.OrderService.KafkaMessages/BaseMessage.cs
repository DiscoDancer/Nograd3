namespace Nograd.OrderService.KafkaMessages;

public abstract class BaseMessage
{
    public string? TypeName { get; set; }
}