using Nograd.OrderService.Commands.Domain;

namespace Nograd.OrderService.Commands.Infrastructure.EventStore;

public static class WebApplicationBuilderExtensions
{
    public static void UseEventStore(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEventStore, EventStore>();
    }
}