using Nograd.ProductService.Commands.Features.CreateProduct.Commands;
using Nograd.ProductService.Commands.Features.CreateProduct.Controllers;

namespace Nograd.ProductService.Commands.Features.CreateProduct.Mappers;

public interface ICreateProductControllerInputToCommandMapper
{
    CreateProductCommand Map(CreateProductControllerInput input, Guid productId);
}