using Nograd.OrderService.Queries.Persistence;
using Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Mappers;

namespace Nograd.OrderService.Queries.WepApi.Features.GetOrderById;

public static class WebApplicationBuilderExtensions
{
    public static void UseGetOrderByIdFeature(this WebApplicationBuilder builder)
    {
        builder.UseReadRepositories();
        builder.Services.AddScoped<IGetOrderByIdMapper, GetOrderByIdMapper>();
    }
}