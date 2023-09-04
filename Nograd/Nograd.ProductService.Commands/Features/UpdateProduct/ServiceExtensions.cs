namespace Nograd.ProductService.Commands.Features.UpdateProduct;

public static class ServiceExtensions
{
    public static void UseUpdateProductFeature(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IUpdateProductControllerInputToCommandMapper, UpdateProductControllerInputToCommandMapper>();
    }
}