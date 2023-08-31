using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.RemoveProduct
{
    public sealed class RemoveProductControllerInput: BaseControllerInput
    {
        public Guid? ProductId { get; set; }
    }
}
