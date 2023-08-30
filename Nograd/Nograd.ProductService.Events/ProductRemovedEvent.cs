namespace Nograd.ProductService.Events;

public sealed class ProductRemovedEvent : BaseEvent
{
    public ProductRemovedEvent(Guid productId) : base(nameof(ProductRemovedEvent))
    {
        if (productId == Guid.Empty) throw new ArgumentException(nameof(productId));

        ProductId = productId;
    }

    public Guid? ProductId { get; set; }
}