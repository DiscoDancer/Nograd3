using Nograd.ProductService.Commands.Features.UpdateProduct.Mappers;

namespace Nograd.ProductService.Commands.Features.UpdateProduct;

public static class WebApplicationBuilderExtensions
{
    public static void UseUpdateProductFeature(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<IUpdateProductControllerInputToCommandMapper, UpdateProductControllerInputToCommandMapper>();
    }
}