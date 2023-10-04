using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders;
using Nograd.OrderService.Queries.WepApi.Features.GetOrderById;

namespace Nograd.OrderService.Queries.WepApi.Features;

public static class WebApplicationBuilderExtensions
{
    public static void UseFeatures(this WebApplicationBuilder builder)
    {
        builder.UseGetAllOrdersFeature();
        builder.UseGetOrderByIdFeature();
    }
}