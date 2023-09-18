using Nograd.ProductService.Queries.Persistence;
using Nograd.ProductService.Queries.WepApi.Features.GetProductById.Mappers;

namespace Nograd.ProductService.Queries.WepApi.Features.GetProductById;

public static class WebApplicationBuilderExtensions
{
    public static void UseGetProductByIdFeature(this WebApplicationBuilder builder)
    {
        builder.UseReadProductRepository();
        builder.Services.AddScoped<IGetProductByIdMapper, GetProductByIdMapper>();
    }
}