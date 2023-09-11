using Nograd.OrderService.Commands.Features.RemoveOrder.Mappers;

namespace Nograd.OrderService.Commands.Features.RemoveOrder;

public static class ServiceExtensions
{
    public static void UseRemoveOrderFeature(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IRemoveOrderControllerInputToCommandMapper, RemoveOrderControllerInputToCommandMapper>();
    }
}