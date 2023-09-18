using Nograd.ProductService.Queries.WepApi.Features.GetAllProducts;
using Nograd.ProductService.Queries.WepApi.Features.GetProductById;

namespace Nograd.ProductService.Queries.WepApi.Features;

public static class WebApplicationBuilderExtensions
{
    public static void UseFeatures(this WebApplicationBuilder builder)
    {
        builder.UseGetAllProductsFeature();
        builder.UseGetProductByIdFeature();
    }
}