using Nograd.OrderService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

namespace Nograd.OrderService.Queries.MessageConsumer.Infrastructure;

public static class WebApplicationBuilderExtensions
{
    public static void UseInfrastructure(this WebApplicationBuilder builder)
    {
        builder.UseKafkaConsumer();
    }
}