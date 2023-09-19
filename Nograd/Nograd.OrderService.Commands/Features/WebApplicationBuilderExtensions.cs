using Nograd.OrderService.Commands.Domain;
using Nograd.OrderService.Commands.Features.CreateOrder;
using Nograd.OrderService.Commands.Features.RemoveOrder;
using Nograd.OrderService.Commands.Features.UpdateOrder;
using Nograd.ProductService.Queries.Client;

namespace Nograd.OrderService.Commands.Features;

public static class WebApplicationBuilderExtensions
{
    public static void UseFeatures(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IOrderEventHandlingStrategy, SaveAndNotifyEventHandlingStrategy>();
        builder.UseProductQueriesClient();

        builder.UseCreateOrderFeature();
        builder.UseUpdateOrderFeature();
        builder.UseRemoveOrderFeature();
    }
}