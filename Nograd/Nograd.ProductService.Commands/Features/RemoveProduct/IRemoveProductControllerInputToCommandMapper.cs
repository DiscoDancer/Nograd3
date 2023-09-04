namespace Nograd.ProductService.Commands.Features.RemoveProduct
{
    public interface IRemoveProductControllerInputToCommandMapper
    {
        RemoveProductCommand Map(RemoveProductControllerInput input);
    }
}
