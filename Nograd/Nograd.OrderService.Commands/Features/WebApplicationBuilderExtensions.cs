using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Features.CreateOrder;
using Nograd.OrderService.Commands.Features.RemoveOrder;
using Nograd.OrderService.Commands.Features.UpdateOrder;

namespace Nograd.OrderService.Commands.Features;

public static class WebApplicationBuilderExtensions
{
    public static void UseFeatures(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IOrderEventHandlingStrategy, SaveAndNotifyEventHandlingStrategy>();
        builder.UseCreateOrderFeature();
        builder.UseUpdateOrderFeature();
        builder.UseRemoveOrderFeature();
    }
}