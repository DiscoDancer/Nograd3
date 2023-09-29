using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Nograd.OrderService.Commands.Client;

public static class WebApplicationBuilderExtensions
{
    public static void UseOrderCommandsClient(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<OrderServiceCommandsConfig>(
            builder.Configuration.GetSection(nameof(OrderServiceCommandsConfig)));
        var config = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<OrderServiceCommandsConfig>>();

        if (string.IsNullOrWhiteSpace(config?.Value?.OrderServiceCommandsBaseUrl))
            throw new Exception("Can't read order commands service base url from configuration.");

        builder.Services.AddScoped<IOrderCommandsClient, OrderCommandsClient>(_ =>
            new OrderCommandsClient(config.Value.OrderServiceCommandsBaseUrl!));
    }
}