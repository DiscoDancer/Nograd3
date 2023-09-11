using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Features.CreateOrder;
using Nograd.OrderService.Commands.Features.RemoveOrder;
using Nograd.OrderService.Commands.Features.UpdateOrder;

namespace Nograd.OrderService.Commands.Features;

public static class ServiceExtensions
{
    public static void UseFeatures(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IOrderEventHandlingStrategy, SaveAndNotifyEventHandlingStrategy>();
        serviceCollection.UseCreateOrderFeature();
        serviceCollection.UseUpdateOrderFeature();
        serviceCollection.UseRemoveOrderFeature();
    }
}