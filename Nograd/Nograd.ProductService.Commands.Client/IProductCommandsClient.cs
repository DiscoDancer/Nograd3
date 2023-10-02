using Nograd.ProductService.Commands.Features.CreateProduct.Controllers;
using Nograd.ProductService.Commands.Features.RemoveProduct.Controllers;
using Nograd.ProductService.Commands.Features.UpdateProduct.Controllers;

namespace Nograd.ProductService.Commands.Client;

public interface IProductCommandsClient
{
    Task<RemoveProductControllerOutput> RemoveProductAsync(RemoveProductControllerInput input);
    Task<CreateProductControllerOutput> CreateProductAsync(CreateProductControllerInput input);
    Task<UpdateProductControllerOutput> UpdateProductAsync(UpdateProductControllerInput input);
} 