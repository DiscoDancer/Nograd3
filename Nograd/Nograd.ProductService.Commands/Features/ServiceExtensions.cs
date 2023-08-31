using Nograd.ProductService.Commands.Features.Base;
using Nograd.ProductService.Commands.Features.CreateProduct;
using Nograd.ProductService.Commands.Features.RemoveProduct;
using Nograd.ProductService.Commands.Features.UpdateProduct;

namespace Nograd.ProductService.Commands.Features;

public static class ServiceExtensions
{
    public static void UseFeatures(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IProductEventHandlingStrategy, SaveAndNotifyEventHandlingStrategy>();
        serviceCollection.UseCreateProductFeature();
        serviceCollection.UseUpdateProductFeature();
        serviceCollection.UseRemoveProductFeature();
    }
}