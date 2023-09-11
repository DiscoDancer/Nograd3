using Nograd.ProductService.Commands.Features.RemoveProduct.Commands;
using Nograd.ProductService.Commands.Features.RemoveProduct.Controllers;

namespace Nograd.ProductService.Commands.Features.RemoveProduct.Mappers
{
    public interface IRemoveProductControllerInputToCommandMapper
    {
        RemoveProductCommand Map(RemoveProductControllerInput input);
    }
}
