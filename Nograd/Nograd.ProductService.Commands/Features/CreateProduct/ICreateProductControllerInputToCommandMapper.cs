namespace Nograd.ProductService.Commands.Features.CreateProduct;

public interface ICreateProductControllerInputToCommandMapper
{
    CreateProductCommand Map(CreateProductControllerInput input, Guid productId);
}