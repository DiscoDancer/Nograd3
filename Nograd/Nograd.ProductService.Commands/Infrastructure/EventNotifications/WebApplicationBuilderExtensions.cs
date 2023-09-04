using Nograd.ProductService.Commands.Domain;

namespace Nograd.ProductService.Commands.Infrastructure.EventNotifications;

public static class WebApplicationBuilderExtensions
{
    public static void UseEventNotificator(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<KafkaConfig>(builder.Configuration.GetSection(nameof(KafkaConfig)));

        builder.Services.AddScoped<IEventNotificator, EventNotificator>();
        builder.Services.AddScoped<IEventToMessageMapper, EventToMessageMapper>();
    }
}