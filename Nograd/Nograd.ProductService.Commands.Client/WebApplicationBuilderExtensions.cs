using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Nograd.ProductService.Commands.Client;

public static class WebApplicationBuilderExtensions
{
    public static void UseProductCommandsClient(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ProductServiceCommandsConfig>(builder.Configuration.GetSection(nameof(ProductServiceCommandsConfig)));
        var config = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<ProductServiceCommandsConfig>>();

        if (string.IsNullOrWhiteSpace(config?.Value?.ProductServiceCommandsBaseUrl))
            throw new Exception("Can't read product commands service base url from configuration.");

        builder.Services.AddScoped<IProductCommandsClient, ProductCommandsClient>(_ =>
            new ProductCommandsClient(config.Value.ProductServiceCommandsBaseUrl!));
    }
}