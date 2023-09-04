using MediatR;

namespace Nograd.ProductService.Commands.Features.RemoveProduct;

public sealed class RemoveProductCommand : IRequest
{
    public RemoveProductCommand(Guid productId)
    {
        if (productId == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(productId));

        ProductId = productId;
    }

    public Guid ProductId { get; }
}