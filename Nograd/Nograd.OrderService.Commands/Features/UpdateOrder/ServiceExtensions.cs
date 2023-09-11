using Nograd.OrderService.Commands.Features.UpdateOrder.Mappers;

namespace Nograd.OrderService.Commands.Features.UpdateOrder;

public static class ServiceExtensions
{
    public static void UseUpdateOrderFeature(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IUpdateOrderControllerInputToCommandMapper, UpdateOrderControllerInputToCommandMapper>();
    }
}