using Nograd.ProductService.Queries.MessageConsumer.Infrastructure.KafkaConsumer;
using Nograd.ProductService.Queries.Persistence;

namespace Nograd.ProductService.Queries.MessageConsumer.Infrastructure;

public static class WebApplicationBuilderExtensions
{
    public static void UseInfrastructure(this WebApplicationBuilder builder)
    {
        builder.UseWriteProductRepository();
        builder.UseKafkaConsumer();
    }
}