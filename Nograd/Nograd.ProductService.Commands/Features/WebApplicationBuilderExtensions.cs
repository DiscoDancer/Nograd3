using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Commands.Features.CreateProduct;
using Nograd.ProductService.Commands.Features.RemoveProduct;
using Nograd.ProductService.Commands.Features.UpdateProduct;

namespace Nograd.ProductService.Commands.Features;

public static class WebApplicationBuilderExtensions
{
    public static void UseFeatures(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IProductEventHandlingStrategy, SaveAndNotifyEventHandlingStrategy>();
        builder.UseCreateProductFeature();
        builder.UseUpdateProductFeature();
        builder.UseRemoveProductFeature();
    }
}