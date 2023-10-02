using Nograd.ProductService.Commands.Features.RemoveProduct.Controllers;

namespace Nograd.ProductService.Commands.Client;

public interface IProductCommandsClient
{
    Task<RemoveProductControllerOutput> RemoveProductAsync(RemoveProductControllerInput input);
}