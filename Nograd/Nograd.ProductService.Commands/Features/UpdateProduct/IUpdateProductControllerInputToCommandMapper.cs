namespace Nograd.ProductService.Commands.Features.UpdateProduct
{
    public interface IUpdateProductControllerInputToCommandMapper
    {
        UpdateProductCommand Map(UpdateProductControllerInput input);
    }
}
