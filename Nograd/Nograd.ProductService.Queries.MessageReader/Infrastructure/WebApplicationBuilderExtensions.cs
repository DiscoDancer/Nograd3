using Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure;

public static class WebApplicationBuilderExtensions
{
    public static void UseInfrastructure(this WebApplicationBuilder builder)
    {
        builder.UseKafkaConsumer();
    }
}