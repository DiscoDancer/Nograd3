using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.CreateProduct;

public class
    CreateProductControllerInputToCommandMapper : IControllerInputToCommandMapper<CreateProductControllerInput,
        CreateProductCommand>
{
    public CreateProductCommand Map(CreateProductControllerInput input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (string.IsNullOrWhiteSpace(input.Name)) throw new ArgumentNullException(nameof(input.Name));
        if (string.IsNullOrWhiteSpace(input.Description)) throw new ArgumentNullException(nameof(input.Description));
        if (string.IsNullOrWhiteSpace(input.Category)) throw new ArgumentNullException(nameof(input.Category));
        if (input.Price <= 0) throw new ArgumentOutOfRangeException(nameof(input.Price));

        return new CreateProductCommand(
            name: input.Name,
            description: input.Description,
            category: input.Category,
            price: input.Price);
    }
}