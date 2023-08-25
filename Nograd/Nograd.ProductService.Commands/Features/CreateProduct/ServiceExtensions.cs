using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.CreateProduct
{
    public static class ServiceExtensions
    {
        public static void UseCreateProductFeature(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IControllerInputToCommandMapper<CreateProductControllerInput, CreateProductCommand>, CreateProductControllerInputToCommandMapper>();
        }
    }
}
