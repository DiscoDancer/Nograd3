namespace Nograd.ProductServices.KafkaMessages;

public sealed record ProductUpdatedMessage(
    string Name,
    string Description,
    string Category,
    decimal Price,
    Guid ProductId
) : BaseMessage
{
    public override string TypeName => nameof(ProductUpdatedMessage);
}