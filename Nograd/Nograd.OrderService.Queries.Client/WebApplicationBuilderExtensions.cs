using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Nograd.OrderService.Queries.Client;

public static class WebApplicationBuilderExtensions
{
    public static void UseOrderQueriesClient(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<OrderQueriesClientConfig>(builder.Configuration.GetSection(nameof(OrderQueriesClientConfig)));
        var orderServiceClientConfig = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<OrderQueriesClientConfig>>();

        if (string.IsNullOrWhiteSpace(orderServiceClientConfig?.Value?.OrderQueriesBaseUrl))
            throw new Exception("Can't read order service queries base url from configuration.");

        builder.Services.AddScoped<IOrderQueriesClient, OrderQueriesClient>(_ => new OrderQueriesClient(orderServiceClientConfig.Value.OrderQueriesBaseUrl!));
    }
}