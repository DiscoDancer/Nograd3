namespace Nograd.ProductServices.KafkaMessages;

public sealed record ProductRemovedMessage(Guid ProductId) : BaseMessage
{
    public override string TypeName => nameof(ProductRemovedMessage);
}