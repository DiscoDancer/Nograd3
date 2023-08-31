using Nograd.ProductService.Commands.Features.Base;

namespace Nograd.ProductService.Commands.Features.RemoveProduct
{
    public static class ServiceExtensions
    {
        public static void UseRemoveProductFeature(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IControllerInputToCommandMapper<RemoveProductControllerInput, RemoveProductCommand>, RemoveProductControllerInputToCommandMapper>();
        }
    }
}
