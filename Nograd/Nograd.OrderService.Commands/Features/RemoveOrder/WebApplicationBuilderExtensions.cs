using Nograd.OrderService.Commands.Features.RemoveOrder.Mappers;

namespace Nograd.OrderService.Commands.Features.RemoveOrder;

public static class WebApplicationBuilderExtensions
{
    public static void UseRemoveOrderFeature(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddTransient<IRemoveOrderControllerInputToCommandMapper, RemoveOrderControllerInputToCommandMapper>();
    }
}