namespace Nograd.ProductServices.KafkaMessages;

public abstract record BaseMessage()
{
    public abstract string TypeName { get; }
}