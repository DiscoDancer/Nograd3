using Nograd.OrderService.Commands.Infrastructure.EventNotifications;
using Nograd.OrderService.Commands.Infrastructure.EventStore;

namespace Nograd.OrderService.Commands.Infrastructure;

public static class WebApplicationBuilderExtensions
{
    public static void UseInfrastructure(this WebApplicationBuilder builder)
    {
        builder.UseEventStore();
        builder.UseEventNotificator();
    }
}