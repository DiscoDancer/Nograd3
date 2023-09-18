using Nograd.OrderService.Commands.Features.UpdateOrder.Mappers;

namespace Nograd.OrderService.Commands.Features.UpdateOrder;

public static class WebApplicationBuilderExtensions
{
    public static void UseUpdateOrderFeature(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<IUpdateOrderControllerInputToCommandMapper, UpdateOrderControllerInputToCommandMapper>();
    }
}