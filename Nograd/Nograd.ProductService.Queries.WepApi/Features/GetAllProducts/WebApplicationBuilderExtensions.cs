using Nograd.ProductService.Queries.Persistence;

namespace Nograd.ProductService.Queries.WepApi.Features.GetAllProducts;

public static class WebApplicationBuilderExtensions
{
    public static void UseGetAllProductsFeature(this WebApplicationBuilder builder)
    {
        builder.UseReadProductRepository();
        builder.Services.AddScoped<IGetAllProductsMapper, GetAllProductsMapper>();
    }
}