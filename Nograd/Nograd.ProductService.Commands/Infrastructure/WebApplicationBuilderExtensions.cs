using Nograd.ProductService.Commands.Infrastructure.EventNotifications;
using Nograd.ProductService.Commands.Infrastructure.EventStore;

namespace Nograd.ProductService.Commands.Infrastructure;

public static class WebApplicationBuilderExtensions
{
    public static void UseInfrastructure(this WebApplicationBuilder builder)
    {
        builder.UseEventStore();
        builder.UseEventNotificator();
    }
}