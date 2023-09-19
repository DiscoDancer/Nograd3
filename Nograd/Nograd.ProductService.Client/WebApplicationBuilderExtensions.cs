using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Nograd.ProductService.Queries.Client;

public static class WebApplicationBuilderExtensions
{
    public static void UseProductQueriesClient(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ProductServiceClientConfig>(builder.Configuration.GetSection(nameof(ProductServiceClientConfig)));
        var productServiceClientConfig = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<ProductServiceClientConfig>>();

        if (string.IsNullOrWhiteSpace(productServiceClientConfig?.Value?.ProductServiceBaseUrl))
            throw new Exception("Can't read product service base url from configuration.");

        builder.Services.AddScoped<IProductQueriesClient, ProductQueriesClient>(_ => new ProductQueriesClient(productServiceClientConfig.Value.ProductServiceBaseUrl!));
    }
}