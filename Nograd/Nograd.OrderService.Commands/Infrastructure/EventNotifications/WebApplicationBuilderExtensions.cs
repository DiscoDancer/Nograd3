using Nograd.OrderService.Commands.Domain;

namespace Nograd.OrderService.Commands.Infrastructure.EventNotifications;

public static class WebApplicationBuilderExtensions
{
    public static void UseEventNotificator(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEventNotificator, EventNotificator>();
    }
}