using Nograd.ProductService.Commands.Features.CreateProduct.Mappers;

namespace Nograd.ProductService.Commands.Features.CreateProduct;

public static class WebApplicationBuilderExtensions
{
    public static void UseCreateProductFeature(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<ICreateProductControllerInputToCommandMapper, CreateProductControllerInputToCommandMapper>();
    }
}