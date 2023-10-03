using Nograd.OrderService.Queries.Persistence.Entities;
using Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Controllers;

namespace Nograd.OrderService.Queries.WepApi.Features.GetAllOrders.Mappers;

public interface IGetAllOrdersMapper
{
    public GetAllOrdersControllerOutputOrder Map(OrderEntity order);
}