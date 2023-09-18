using Nograd.ProductService.Commands.Features.RemoveProduct.Mappers;

namespace Nograd.ProductService.Commands.Features.RemoveProduct;

public static class WebApplicationBuilderExtensions
{
    public static void UseRemoveProductFeature(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<IRemoveProductControllerInputToCommandMapper, RemoveProductControllerInputToCommandMapper>();
    }
}