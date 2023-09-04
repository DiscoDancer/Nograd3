namespace Nograd.ProductService.Commands.Features.UpdateProduct;

public sealed class
    UpdateProductControllerInputToCommandMapper : IUpdateProductControllerInputToCommandMapper
{
    public UpdateProductCommand Map(UpdateProductControllerInput input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (string.IsNullOrWhiteSpace(input.Name)) throw new ArgumentNullException(nameof(input.Name));
        if (string.IsNullOrWhiteSpace(input.Description)) throw new ArgumentNullException(nameof(input.Description));
        if (string.IsNullOrWhiteSpace(input.Category)) throw new ArgumentNullException(nameof(input.Category));
        if (input.Price <= 0) throw new ArgumentOutOfRangeException(nameof(input.Price));
        if (input.ProductId == null || input.ProductId == Guid.Empty)
            throw new ArgumentNullException(nameof(input.ProductId));

        return new UpdateProductCommand(
            input.Name,
            input.Description,
            input.Category,
            input.Price,
            input.ProductId.Value);
    }
}