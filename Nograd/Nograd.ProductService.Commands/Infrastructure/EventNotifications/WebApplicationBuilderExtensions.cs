using Confluent.Kafka;
using Nograd.ProductService.Commands.Domain;
using Nograd.ProductService.Commands.Infrastructure.EventStore;

namespace Nograd.ProductService.Commands.Infrastructure.EventNotifications;

public static class WebApplicationBuilderExtensions
{
    public static void UseEventNotificator(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<KafkaConfig>(builder.Configuration.GetSection(nameof(KafkaConfig)));

        //var x = builder.Configuration.GetSection(nameof(ProducerConfig));

        //builder.Services.Configure<ProducerConfig>(builder.Configuration.GetSection(nameof(ProducerConfig)));

        builder.Services.AddScoped<IEventNotificator, EventNotificator>();
    }
}