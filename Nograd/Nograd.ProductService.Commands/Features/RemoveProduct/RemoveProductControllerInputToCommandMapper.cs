using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.RemoveProduct
{
    public sealed class RemoveProductControllerInputToCommandMapper : IControllerInputToCommandMapper<RemoveProductControllerInput, RemoveProductCommand>
    {
        public RemoveProductCommand Map(RemoveProductControllerInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (input.ProductId == null || input.ProductId == Guid.Empty) throw new ArgumentNullException(nameof(input.ProductId));

            return new RemoveProductCommand(input.ProductId.Value);
        }
    }
}
