using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;
using Nograd.OrderService.Queries.WepApi.Features.GetOrderById.Controllers;

namespace Nograd.OrderService.Queries.Client;

public interface IOrderQueriesClient
{
    Task<GetAllOrdersControllerOutput> GetAllOrdersAsync();
    Task<GetOrderByIdControllerOutputOrder?> GetOrderByIdOrDefaultAsync(Guid id);
}