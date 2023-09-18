using Nograd.OrderService.Commands.Features.CreateOrder.Mappers;

namespace Nograd.OrderService.Commands.Features.CreateOrder;

public static class WebApplicationBuilderExtensions
{
    public static void UseCreateOrderFeature(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<ICreateOrderControllerInputToCommandMapper, CreateOrderControllerInputToCommandMapper>();
    }
}