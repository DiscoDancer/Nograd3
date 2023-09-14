using Nograd.OrderService.Queries.Persistence;
using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Mappers;

namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders;

public static class WebApplicationBuilderExtensions
{
    public static void UseGetAllOrdersFeature(this WebApplicationBuilder builder)
    {
        builder.UseReadOrderRepository();
        builder.Services.AddScoped<IGetAllOrdersMapper, GetAllOrdersMapper>();
    }
}