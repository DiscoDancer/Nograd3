using System.Text.Json.Serialization;

namespace Nograd.ProductServices.KafkaMessages;

public sealed class ProductCreatedMessage : BaseMessage
{
    public ProductCreatedMessage(
        string name,
        string description,
        string category,
        decimal price,
        Guid productId)
    {
        Name = name;
        Description = description;
        Category = category;
        Price = price;
        ProductId = productId;
        TypeName = nameof(ProductCreatedMessage);
    }

    [JsonConstructorAttribute]
    public ProductCreatedMessage()
    {
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public decimal? Price { get; set; }
    public Guid? ProductId { get; set; }
}