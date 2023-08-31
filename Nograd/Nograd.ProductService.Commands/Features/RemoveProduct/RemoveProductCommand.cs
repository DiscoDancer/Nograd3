using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.RemoveProduct
{
    public sealed class RemoveProductCommand: BaseCommand
    {
        public RemoveProductCommand(Guid productId)
        {
            if (productId == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(productId));

            ProductId = productId;
        }

        public Guid ProductId { get; }
    }
}
