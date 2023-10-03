using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

namespace Nograd.OrderService.Queries.Client;

public interface IOrderQueriesClient
{
    Task<GetAllOrdersControllerOutput> GetAllOrdersAsync();
}