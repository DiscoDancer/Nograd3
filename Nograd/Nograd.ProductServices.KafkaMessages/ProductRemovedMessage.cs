using System.Text.Json.Serialization;

namespace Nograd.ProductServices.KafkaMessages;

public sealed class ProductRemovedMessage : BaseMessage
{
    public ProductRemovedMessage(Guid productId)
    {
        ProductId = productId;
        TypeName = nameof(ProductRemovedMessage);
    }

    [JsonConstructorAttribute]
    public ProductRemovedMessage()
    {
    }

    public Guid? ProductId { get; set; }
}