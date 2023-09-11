using Nograd.ProductService.Commands.Features.CreateProduct.Commands;
using Nograd.ProductService.Commands.Features.CreateProduct.Controllers;

namespace Nograd.ProductService.Commands.Features.CreateProduct.Mappers;

public class CreateProductControllerInputToCommandMapper : ICreateProductControllerInputToCommandMapper
{
    public CreateProductCommand Map(CreateProductControllerInput input, Guid productId)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (string.IsNullOrWhiteSpace(input.Name)) throw new ArgumentNullException(nameof(input.Name));
        if (string.IsNullOrWhiteSpace(input.Description)) throw new ArgumentNullException(nameof(input.Description));
        if (string.IsNullOrWhiteSpace(input.Category)) throw new ArgumentNullException(nameof(input.Category));
        if (input.Price <= 0) throw new ArgumentOutOfRangeException(nameof(input.Price));
        if (productId == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(productId));

        return new CreateProductCommand(
            name: input.Name,
            description: input.Description,
            category: input.Category,
            price: input.Price,
            productId: productId);
    }
}