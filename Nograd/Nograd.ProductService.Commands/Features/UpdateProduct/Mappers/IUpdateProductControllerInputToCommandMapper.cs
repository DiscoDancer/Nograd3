using Nograd.ProductService.Commands.Features.UpdateProduct.Commands;
using Nograd.ProductService.Commands.Features.UpdateProduct.Controllers;

namespace Nograd.ProductService.Commands.Features.UpdateProduct.Mappers
{
    public interface IUpdateProductControllerInputToCommandMapper
    {
        UpdateProductCommand Map(UpdateProductControllerInput input);
    }
}
